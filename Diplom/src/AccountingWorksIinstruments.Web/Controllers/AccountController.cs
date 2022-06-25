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
    public class AccountController : Controller
    {
        private const string _userRole = "User";
        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> identityUserManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
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

            var user = new User { Email = model.Email, UserName = model.Email };
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            await _identityUserManager.AddToRoleAsync(user, _userRole);
            if (result.Succeeded)
            {
                //    var cart = new BusinessLogic.DtoModels.CartDto
                //    {
                //        AspNetUserId = user.Id,
                //    };
                //    _cartService.Create(cart);

                //    var amount = new BusinessLogic.DtoModels.UsersAmountDto
                //    {
                //        AspNetUserId = user.Id,
                //        Amount = 0,
                //    };
                //    _amountService.Create(amount);

                await _signInManager.SignInAsync(user, false);
                return RedirectToAction(Url.Action(nameof(Index), nameof(HomeController)));
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
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }

            return View(model);
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
