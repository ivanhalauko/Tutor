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

        public AccountController(UserManager<IdentityUser> identityUserManager, SignInManager<IdentityUser> signInManager)
        {
            _identityUserManager = identityUserManager;
            _signInManager = signInManager;
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
    }
}
