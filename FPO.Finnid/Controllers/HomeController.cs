using finnit.Repository.RequestCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using finnit.Repository;

namespace finnit.Controllers
{
    public class HomeController : Controller
    {
        IMediator _m;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _m = mediator;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Route("/about-us")]
        public IActionResult about()
        {
            return View();
        }
        [Route("/blog")]
        public IActionResult blog()
        {
            return View();
        }
        [Route("/contact-us")]
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactMailInquiry([FromBody] ContactMailInquiry ContactMailInquiry)
        {
            var data = (dynamic)null;

            string Name = ContactMailInquiry.Name;
            string Email = ContactMailInquiry.Email;
            string Contact = ContactMailInquiry.Contact;
            string Message = ContactMailInquiry.Message;
            string Body = @"Name :" + Name + "<br/>Email :" + Email + "<br/>Contact :" + Contact + "<br/>Message :" + Message;
            string Subject = "Finnid FPO Enquiry";
            //MyUtility.SendEmail("sales@diptimate.com", Subject, Body);
            //data = MyUtility.SendEmail("info@diptimate.com", Subject, Body);
            data = MyUtility.SendEmail("welisten@finnid.in", Subject, Body);
            SendMailToClient(Email, Name);
            // data = ResponseResult.SuccessResponse("SUCCESS", data);
            return Ok(data);
        }
        public void SendMailToClient(string Email, string Name)
        {
            var html = "<!DOCTYPE html>"
        + "<html lang='en'>"
        + "<head>"
        + "    <meta charset='UTF-8'>"
        + "    <meta name='viewport' content='width=device-width, initial-scale=1.0'>"
        + "    <title>Thank You for Inquiry</title>"
        + "    <style>"
        + "        body {"
        + "            background-color: orange;"
        + "            font-family: Arial, sans-serif;"
        + "        }"
        + "        .container {"
        + "            max-width: 600px;"
        + "            margin: 0 auto;"
        + "            padding: 20px;"
        + "            background-color: #fff;"
        + "            border-radius: 5px;"
        + "            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);"
        + "        }"
        + "        .header {"
        + "            text-align: center;"
        + "        }"
        + "        .logo {"
        + "            max-width: 100px;"
        + "            margin: 20px auto;"
        + "        }"
        + "        .message {"
        + "            text-align: center;"
        + "            margin-top: 20px;"
        + "        }"
        + "        .address {"
        + "            margin-top: 20px;"
        + "            text-align: center;"
        + "        }"
        + "        .disclaimer {"
        + "            font-size: 12px;"
        + "            text-align: center;"
        + "            margin-top: 20px;"
        + "        }"
        + "    </style>"
        + "</head>"
        + "<body>"
        + "    <div class='container'>"
        + "        <div class='header'>"
        + "            <img src='https://erp.finnid.in/Content/img/logo.png' alt='Finnid Infotech Private Limited' class='logo' width='350'>"
        + "            <h1>Thank You for Your Inquiry</h1>"
        + "        </div>"
        + "        <div class='message'>"
        + "            <p>Dear " + Name + ",</p>"
        + "            <p>We would like to express our gratitude for inquiry regarding our services. We have received your message and will get back to you as soon as possible with the information you requested.</p>"
        + "        </div>"
        + "        <div class='address'>"
        + "            <p>Finnid Infotech Private Limited</p>"
        + "            <p>KP-4/371, Kaushalpuri, Khargapur,</p>"
        + "            <p>Gomti Nagar, Lucknow - 226010 (UP)</p>"
        + "        </div>"
        + "        <div class='disclaimer'>"
        + "            <p>Please note that all our email communications are scanned for viruses; however, we recommend that you also take necessary precautions to ensure the security of your system.</p>"
        + "        </div>"
        + "    </div>"
        + "</body>"
        + "</html>";
            MyUtility.SendEmail(Email, "Thank you for contact us.", html);
        }
        [Route("/download")]
        public IActionResult download()
        {
            return View();
        }
        [Route("/faq")]
        public IActionResult faq()
        {
            return View();
        }
        [Route("/feature")]
        public IActionResult feature()
        {
            return View();
        }
        [Route("/pricing")]
        public IActionResult pricing()
        {
            return View();
        }
        [Route("/serviceagreement")]
        public IActionResult serviceagreement()
        {
            return View();
        }
        [Route("/services")]
        public IActionResult services()
        {
            return View();
        }
        [Route("/singleblog")]
        public IActionResult singleblog()
        {
            return View();
        }
        [Route("/srvdetails")]
        public IActionResult srvdetails()
        {
            return View();
        }
        [Route("/terms")]
        public IActionResult terms()
        {
            return View();
        }
        [Route("/training")]
        public IActionResult training()
        {
            return View();
        }
        [Route("/Thankyou")]
        [HttpGet]
        public IActionResult Thankyou()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
        [Route("/nidhi-company-registration")]
        public IActionResult nidhi_compny_registration()
        {
            return View();
        }
        [Route("/public-limited-company-registration")]
        public IActionResult public_compny_registration()
        {
            return View();
        }
        [Route("/private-limited-company-registration")]
        public IActionResult private_compny_registration()
        {
            return View();
        }
        [Route("/producer-company-registration")]
        public IActionResult producer_compny_registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationEnquery([FromBody] RegistrationEnquery registrationenquery)
        {
            var data = await _m.Send(registrationenquery);
            return Ok(data);
        }

        [Route("/index")]
        public IActionResult Home()
        {
            return View();
        }

    }
}
