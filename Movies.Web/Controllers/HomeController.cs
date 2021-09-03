using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.BL.Services;
using Movies.Data;
using Movies.Data.Entities;
using Movies.Web.Models;
using Movies_App.View_Model_Manager;
using System.Diagnostics;
using System.Linq;

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
    }
}
