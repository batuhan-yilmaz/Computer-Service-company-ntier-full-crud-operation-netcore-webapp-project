using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using General.Business.Abstrack;
using General.WebUI.Identity;
using General.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace General.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class AccountController : Controller
    {
        private IControlCenterService _controlCenterService;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        public AccountController(IControlCenterService controlCenterService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _controlCenterService = controlCenterService;
        }
        public IActionResult Login(string ReturnUrl = null)
        {


            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir e-mail adresi bulunamadı.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı mail ile onaylayınız.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Email veya parola yanlış");
            return View(model);

        }
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Home", "Index");
        }
    }
}
