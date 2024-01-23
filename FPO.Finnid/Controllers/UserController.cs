using Microsoft.AspNetCore.Mvc;

namespace finnit.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
