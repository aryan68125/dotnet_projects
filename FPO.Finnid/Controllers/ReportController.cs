using Microsoft.AspNetCore.Mvc;

namespace finnit.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult My_Cart()
        {
            return View();
        }
        public IActionResult My_Order()
        {
            return View();
        }
        public IActionResult PG_Report()
        {
            return View();
        }
    }
}
