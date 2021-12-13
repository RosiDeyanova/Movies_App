using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Web.Models;
using Movies.Web.ViewModel.User;

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
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
