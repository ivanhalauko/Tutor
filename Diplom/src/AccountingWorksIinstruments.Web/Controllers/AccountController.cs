using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private const string _userRole = "worker";
        private readonly UserManager<ApplicationUser> _identityUserManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AccountController(UserManager<ApplicationUser> identityUserManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _identityUserManager = identityUserManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
           // /Account/Index
        public IActionResult Index()
        {
            return View(_identityUserManager.Users.ToList());
        }

        // /Account/Register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email, PositionId=1 };
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            await _identityUserManager.AddToRoleAsync(user, _userRole);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(CheckUpRole));
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult CheckUpRole()
        {
            if (User.IsInRole("worker"))
            {
                return RedirectToAction(nameof(WorkerAccountController.PersonalAccount),nameof(WorkerAccountController).Replace("Controller",""));
            }
            else if (User.IsInRole("Stock Boy"))
            {
                return RedirectToAction(nameof(StockController.StockAccount),nameof(StockController).Replace("Controller",""));
            }

            return RedirectToAction(nameof(HomeController.Error),nameof(HomeController).Replace("Controller",""),new {message = "Contact the Administrator of the site" });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // /Account/Roles
        public IActionResult Roles() => View(_roleManager.Roles.ToList());

        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(name);
        }

        [HttpGet]
        [Route("Account/EditUsersRole/{userId}")]
        public async Task<IActionResult> EditUsersRole(string userId)
        {
            var user = await _identityUserManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _identityUserManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var model = new RoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles,
                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersRole(string userId, List<string> roles)
        {
            var user = await _identityUserManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _identityUserManager.GetRolesAsync(user);
                _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
                await _identityUserManager.AddToRolesAsync(user, addedRoles);
                await _identityUserManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Roles");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userid)
        {
            var user = await _identityUserManager.FindByIdAsync(userid);
            var entitiesViewModel = new DeleteUserViewModel
            {
                Id = userid,
                Email = user.Email,
            };

            return View(entitiesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _identityUserManager.FindByIdAsync(model.Id);
                    var result = await _identityUserManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Error");
            }

            return View(model);
        }
    }
}
