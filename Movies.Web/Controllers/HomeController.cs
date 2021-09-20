using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Services;
using Movies.Data;
using Movies.Web.Models;
using System;
using System.Diagnostics;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesContext _context;
        private readonly IMovieManager _movieManager;

        public HomeController(MoviesContext context, IMovieManager movieManager)
        {
            _context = context;
            _movieManager = movieManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            return RedirectToAction("Index", "Movies"); 
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
