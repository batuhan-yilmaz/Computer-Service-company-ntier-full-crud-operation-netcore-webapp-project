using General.Business.Abstrack;
using General.Entities;
using General.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace General.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]


    public class HomeController : Controller
    {
        private IControlCenterService _controlCenterService;
        public HomeController(IControlCenterService controlCenterService)
        {
            _controlCenterService = controlCenterService;
        }
        public IActionResult Index()
        {
            var Logo = _controlCenterService.GetDefault().Logo;
            ViewData["Logo"] = Logo;
            return View(new ControlCenterModel()
            {
                CompanyServices = _controlCenterService.GetServicesAll(),
                ControlCenters = _controlCenterService.GetAll()

            });
        }


        public IActionResult Services()
        {
            var Logo = _controlCenterService.GetDefault().Logo;
            ViewData["Logo"] = Logo;
            return View(new CompanyServiceModel()
            {
                ControlCenters = _controlCenterService.GetAll(),
                CompanyServices = _controlCenterService.GetServicesAll(),

            });
        }
        public IActionResult ServiceDetail(int? id)
        {
            var Logo = _controlCenterService.GetDefault().Logo;
            ViewData["Logo"] = Logo;
            if (id == null)
            {
               return RedirectToAction("Index");
            }
            CompanyService service = _controlCenterService.GetCompanyServicesById((int)id);
            string myStr = service.longexplanation;   
            myStr = myStr.Trim('"');      
            if (service == null)
            {
                return RedirectToAction("Index");
            }
            return View(new CompanyServiceModel()
            {
                ControlCenters = _controlCenterService.GetAll(),
                icon = service.icon,
                name = service.name,
                image = service.image,
                longexplanation = myStr,
                shortexplanation = service.shortexplanation,                

            });
        }
        [HttpPost]
        public IActionResult CreateContactUs(string Name,string Email,string Subject, string Message)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("rhymerpasha@gmail.com");
            msg.To.Add("bilgi@3escomputer.com");
            msg.Subject = Subject + "/"+ Name + "/" + Email +"/" +  DateTime.Now.ToString();
            msg.Body = Message;
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("rhymerpasha@gmail.com", "14f55b0b");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                return Redirect("/Home");
            }

            finally
            {
                msg.Dispose();

            }


        }
    }
}

