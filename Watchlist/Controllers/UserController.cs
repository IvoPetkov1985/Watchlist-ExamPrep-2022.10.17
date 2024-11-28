using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.DataModels;
using Watchlist.Models;
using static Watchlist.Data.Common.DataConstants;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Watchlist.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, MoviesContrName);
            }

            RegisterFormModel model = new();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            User user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, MoviesContrName);
            }

            LoginFormModel model = new();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            User user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction(AllActionName, MoviesContrName);
                }
            }

            ModelState.AddModelError(string.Empty, LoginFailedMsg);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(IndexActionName, HomeContrName);
        }
    }
}
