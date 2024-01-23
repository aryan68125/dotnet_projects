using Microsoft.AspNetCore.Http;

namespace finnit.Helper
{
    public class RequestInfo: IRequestInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestInfo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetIPAddress()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            }
            return null;
        }
        public string GetHostName()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                return _httpContextAccessor.HttpContext.Request.Host.ToString();
            }
            return null;
        }
    }
}
