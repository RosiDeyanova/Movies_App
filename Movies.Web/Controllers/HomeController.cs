using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Services;
using Movies.Data;
using Movies.Web.Managers;
using Movies.Web.Models;
using Movies.Web.ViewModel.Admin;
using System;
using System.Diagnostics;
using System.Linq;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersManager _usersManager;

        public HomeController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminViewModel adminViewModel)
        {
            try
            {
                if (_usersManager.IsUserRegistered(adminViewModel).Item1 == true)
                {
                    var user = _usersManager.GetUsers().Where(u => u.Id == _usersManager.IsUserRegistered(adminViewModel).Item2).FirstOrDefault();
                    if (user.IsAdmin == true)
                    {
                        return RedirectToAction("Index", "Admin");

                    }
                    return RedirectToAction("Index", "Movies");
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Register(AdminViewModel adminViewModel)
        {
            try
            {
                if (adminViewModel.Password == adminViewModel.RepeatedPassword && _usersManager.IsUserRegistered(adminViewModel).Item1 == false)
                {
                    _usersManager.AddUser(adminViewModel);
                    return RedirectToAction("Index", "Movies");

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
