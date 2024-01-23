using finnit.Helper;
using finnit.Repository.Account;
using finnit.Repository.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace finnit.Controllers
{
    public class AccountController : Controller
    {
        private IMediator _mediator;
        private IRequestInfo _requestInfo;
        public AccountController(IMediator mediator, IRequestInfo requestInfo)
        {
            _mediator = mediator;
            _requestInfo = requestInfo;
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var stateList = await _mediator.Send(new StateCommand { });
            return View(stateList);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpCommand signUpCommand)
        {
            signUpCommand.CreatedIP = _requestInfo.GetIPAddress();
            signUpCommand.HostName = _requestInfo.GetHostName();
            var response = await _mediator.Send(signUpCommand);
            return Json(response);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetCity(int StateId)
        {
            var stateList = await _mediator.Send(new CityCommand { StateId = StateId });
            return Json(stateList);
        }

        [HttpGet]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
            return RedirectToAction("Index","Home");
        }
    }
}
