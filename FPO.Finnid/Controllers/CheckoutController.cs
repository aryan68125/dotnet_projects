using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace finnit.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CheckoutController : Controller
    {
        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOut()
        {
            return Json("done");
        }
    }
}
