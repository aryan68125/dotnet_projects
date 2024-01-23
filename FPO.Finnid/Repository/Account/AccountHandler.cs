using finnit.Repository.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace finnit.Repository.Account
{
    public class AccountHandler : IRequestHandler<LoginCommand, object>, IRequestHandler<SignUpCommand, object>
    {
        private IDataLayer _dataLayer;
        private IHttpContextAccessor _httpContextAccessor;
        public AccountHandler(IDataLayer dataLayer, IHttpContextAccessor httpContextAccessor)
        {
            _dataLayer = dataLayer;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var Result = (dynamic)null;
            if (string.IsNullOrEmpty(request.Email))
            {
                Result = ResponseResult.FailedResponse("Email is required.");
                return Result;
            }
            else if (string.IsNullOrEmpty(request.Password))
            {
                Result = ResponseResult.FailedResponse("Password is required.");
                return Result;
            }
            Result = _dataLayer.QueryWithOutCusRes("GetLoginDetail", new
            {
                request.Email,
                request.Password
            });
            if (Convert.ToInt32(Result.responseCode) == 200)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, Convert.ToString(Result.UserRoleCode)));
                claims.Add(new Claim("StateName", Convert.ToString(Result.StateName)));
                claims.Add(new Claim("WebsiteId", Convert.ToString(Result.WebsiteId)));
                claims.Add(new Claim("CustomerId", Convert.ToString(Result.CustomerId)));
                claims.Add(new Claim("UserRoleId", Convert.ToString(Result.UserRoleId)));
                claims.Add(new Claim("LoginId", Convert.ToString(Result.Id)));
                claims.Add(new Claim(ClaimTypes.Email, Convert.ToString(Result.Email)));
                claims.Add(new Claim(ClaimTypes.MobilePhone, Convert.ToString(Result.Mobile)));
                claims.Add(new Claim(ClaimTypes.Role, Convert.ToString(Result.UserRoleName)));
                claims.Add(new Claim(ClaimTypes.GivenName, Convert.ToString(Result.Name)));

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddYears(1)
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
            }
            return await Task.FromResult(Result);
        }

        public async Task<object> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var Result = (dynamic)null;
            Result = _dataLayer.Query("CustomerSignUp", new
            {
                request.Id,
                request.Name,
                request.Email,
                request.Mobile,
                request.Password,
                request.CreatedIP,
                request.StateId,
                request.CityId,
                request.HostName,
            });
            if (Result.responseCode == 200)
            {
                //string Body = "Dear " + request.Name + ", Thanks for choosing Finind. Your LoginId is " + request.Email + ". Your Password is " + request.Password + ". Please change your password now. FPO by FINNID";
                //string Subject = "Registration Login and Password From Finind services..";
                //MyUtility.SendEmail(request.Email, Subject, Body);
                //MyUtility.SendSms(Body, request.Mobile);
                Result = ResponseResult.SuccessResponse("Congratulations! check userid and password your email or mobile number .");
            }
            return await Task.FromResult(Result);
        }
    }
}
