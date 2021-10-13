using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.Models;
using Movies.Web.ViewModel.User;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserViewModel userViewModel, string returnUrl)
        {
                var user = _userManager.GetRegisteredUser(userViewModel.Email,userViewModel.Password);
                if (user != null)
                {
                    var claimsIdentity = new ClaimsIdentity(new[]
                       {
                            new Claim(ClaimTypes.Email, user.Email)
                            //...
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else if (user.IsAdmin == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel.Password == userViewModel.RepeatedPassword && _userManager.GetRegisteredUser(userViewModel.Email,userViewModel.Password) == null)
                {
                    var userModel = _mapper.Map<UserModel>(userViewModel);
                    _userManager.AddUser(userModel);
                    return RedirectToAction("Index", "User");

                }
                return RedirectToAction("Index", "Home");

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
