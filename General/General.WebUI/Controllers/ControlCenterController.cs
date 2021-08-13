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
    [AutoValidateAntiforgeryToken]

    public class ControlCenterController : Controller
    {
        private IControlCenterService _controlCenterService;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public ControlCenterController(IControlCenterService controlCenterService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _controlCenterService = controlCenterService;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(new ControlCenterModel()
            {
                CompanyServices = _controlCenterService.GetServicesAll(),
                ControlCenters = _controlCenterService.GetAll()

            });
        }
        public IActionResult OurServices()
        {
            return View(new ControlCenterModel()
            {
                CompanyServices = _controlCenterService.GetServicesAll(),
                ControlCenters = _controlCenterService.GetAll()

            });
        }
        // SERVİS EDİT SAYFASI
        public IActionResult ServiceDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var controlcenterId = _controlCenterService.GetDefault().Id;
            var entity = _controlCenterService.GetCompanyServicesById((int)id);

            var model = new CompanyServiceModel()

            {
                Id = entity.Id,
                name = entity.name,
                icon = entity.icon,
                image = entity.image,
                longexplanation = entity.longexplanation,
                shortexplanation = entity.shortexplanation,
                ControlCenterId = controlcenterId,

            };


            return View(model);

        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> ServiceDetail(CompanyServiceModel model, IFormFile file)
        {
            var entity = _controlCenterService.GetCompanyServicesById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.name = model.name;
            entity.icon = model.icon;
            entity.longexplanation = model.longexplanation;
            entity.shortexplanation = model.shortexplanation;

            if (file != null)
            {
                string ImageUrl = entity.image;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\services", ImageUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.image = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\services", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }


            }

            _controlCenterService.Update(entity);

            return RedirectToAction("Index");
        }
        public IActionResult ImageEditor()
        {
            return View();
        }
        public IActionResult CreateService()
        {
            return View(new CompanyServiceModel());
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]

        public async Task<IActionResult> CreateService(CompanyServiceModel model, IFormFile file)
        {
            var controlcenterId = _controlCenterService.GetDefault().Id;

            if (!ModelState.IsValid)
            {

                var entity = new CompanyService()

                {

                    name = model.name,
                    icon = model.icon,
                    image = file.FileName,
                    longexplanation = model.longexplanation,
                    shortexplanation = model.shortexplanation,
                    ControlCenterId = controlcenterId,

                };

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\services", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                _controlCenterService.Create(entity);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult DeleteService(int serviceId)
        {
            var entity = _controlCenterService.GetCompanyServicesById(serviceId);
            if (entity != null)
            {
                _controlCenterService.Delete(entity);

            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> EditControlCenterSettings(ControlCenterModel model, IFormFile logofile, IFormFile parallax1, IFormFile parallax2, IFormFile parallax3, IFormFile mainsliderimage, IFormFile mainsliderimage2, IFormFile mainsliderimage3, IFormFile mainsliderimage4)
        {

            var entity = _controlCenterService.GetDefault();
            if (entity == null)
            {
                return NotFound();
            }
            entity.contract1tr = model.contract1tr;
            entity.contract2tr = model.contract2tr;
            entity.contract3tr = model.contract3tr;
            entity.contract4tr = model.contract4tr;
            entity.socialnetwork1 = model.socialnetwork1;
            entity.socialnetwork2 = model.socialnetwork2;
            entity.socialnetwork3 = model.socialnetwork3;
            entity.socialnetwork4 = model.socialnetwork4;
            entity.Adress = model.Adress;
            entity.Phone = model.Phone;
            entity.Email = model.Email;
            entity.webadress = model.webadress;
            entity.Adress = model.Adress;
            entity.Phone = model.Phone;
            entity.Email = model.Email;
            entity.webadress = model.webadress;
            if (logofile != null)
            {
                string LogoUrl = entity.Logo;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", LogoUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.Logo = logofile.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", logofile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await logofile.CopyToAsync(stream);
                }
            }
            if (mainsliderimage != null)
            {
                string LogoUrl = entity.Logo;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", LogoUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.mainsliderimage = mainsliderimage.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", mainsliderimage.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await mainsliderimage.CopyToAsync(stream);
                }
            }
            if (mainsliderimage2 != null)
            {
                string LogoUrl = entity.Logo;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", LogoUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.mainsliderimage2 = mainsliderimage2.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", mainsliderimage2.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await mainsliderimage2.CopyToAsync(stream);
                }
            }
            if (mainsliderimage3 != null)
            {
                string LogoUrl = entity.Logo;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", LogoUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.mainsliderimage3 = mainsliderimage3.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", mainsliderimage3.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await mainsliderimage3.CopyToAsync(stream);
                }
            }
            if (mainsliderimage4 != null)
            {
                string LogoUrl = entity.Logo;
                var deletepath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", LogoUrl);
                if (System.IO.File.Exists(deletepath1))
                {
                    System.IO.File.Delete(deletepath1);
                }
                entity.mainsliderimage3 = mainsliderimage4.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\slider", mainsliderimage4.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await mainsliderimage4.CopyToAsync(stream);
                }
            }
            if (parallax1 != null)
            {
                string Logo2Url = entity.parallax1;
                var deletepath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", Logo2Url);
                if (System.IO.File.Exists(deletepath2))
                {
                    System.IO.File.Delete(deletepath2);
                }
                entity.parallax1 = parallax1.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", parallax1.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await parallax1.CopyToAsync(stream);
                }
            }
            if (parallax2 != null)
            {
                string Logo2Url = entity.parallax2;
                var deletepath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", Logo2Url);
                if (System.IO.File.Exists(deletepath2))
                {
                    System.IO.File.Delete(deletepath2);
                }
                entity.parallax2 = parallax2.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", parallax2.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await parallax2.CopyToAsync(stream);
                }
            }
            if (parallax3 != null)
            {
                string Logo2Url = entity.parallax3;
                var deletepath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", Logo2Url);
                if (System.IO.File.Exists(deletepath2))
                {
                    System.IO.File.Delete(deletepath2);
                }
                entity.parallax3 = parallax2.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\parallax", parallax3.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await parallax2.CopyToAsync(stream);
                }
            }

            entity.socialnetwork1 = model.socialnetwork1;
            entity.socialnetwork2 = model.socialnetwork2;
            entity.socialnetwork3 = model.socialnetwork3;
            entity.socialnetwork4 = model.socialnetwork4;
            _controlCenterService.Update(entity);

            TempData["EditControlcenter"] = " ";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateRole()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(CreateRole model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };
            IdentityResult result = await _roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ControlCenter");
            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult UsersList()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index", "ControlCenter");
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = userRoles,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return RedirectToAction("Index", "ControlCenter");
            }
            user.Email = model.Email;
            user.UserName = model.UserName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ControlCenter");
            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "ControlCenter");
            }

            var model = new List<UserRoles>();

            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new UserRoles
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRoles> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Index", "ControlCenter");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
    }
}
