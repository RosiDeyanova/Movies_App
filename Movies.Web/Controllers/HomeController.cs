using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Web.Models;
using Movies.Web.ViewModel.User;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager, IAuthenticationManager authenticationManager, IMapper mapper) : base(authenticationManager, mapper)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            if (User != null && User.IsAdmin == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User != null && User.IsAdmin == false)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserViewModel userViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = _userManager.GetRegisteredUser(userViewModel.Email, userViewModel.Password);
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

        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            if (userViewModel.Password == userViewModel.RepeatedPassword && _userManager.GetRegisteredUser(userViewModel.Email, userViewModel.Password) == null)
            {
                var userModel = _mapper.Map<UserModel>(userViewModel);
                _userManager.AddUser(userModel);
                var userModelFromDB = _userManager.GetUserByEmail(userModel.Email);
                var userViewModelFromDB = _mapper.Map<UserViewModel>(userModelFromDB);
                return RedirectToAction("Index", "User"); //how to pass the vm to this view without it goint to the url!?

            }
            return RedirectToAction("Index", "Home");
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
