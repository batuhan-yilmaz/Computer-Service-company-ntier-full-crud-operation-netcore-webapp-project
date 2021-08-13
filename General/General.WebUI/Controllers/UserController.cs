using General.Business.Abstrack;
using General.Entities;
using General.WebUI.Identity;
using General.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Controllers
{
    [Authorize(Roles = "admin")]

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
