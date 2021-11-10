using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.Web.ViewModel.Admin;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class AdminController : BaseController
    {
        private readonly IUserManager _userManager;
        private readonly IMovieManager _movieManager;
        private readonly IStudioManager _studioManager;
        private readonly IGenreManager _genreManager;


        public AdminController(IUserManager userManager, IMovieManager movieManager, IStudioManager studioManager, IGenreManager genreManager, IAuthenticationManager authenticationManager, IMapper mapper) : base (authenticationManager, mapper)
        {
            _userManager = userManager;
            _genreManager = genreManager;
            _movieManager = movieManager;
            _studioManager = studioManager;
        }

        [HttpGet("admin")]
        public ActionResult Index()
        {
            var adminViewModel = new AdminViewModel()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                AllUsers = _userManager.GetUsers(),
                AllGenres = _genreManager.GetGenres().ToList(),
                AllMovies = _movieManager.GetAllMovies().ToList(),
                AllStudios = _studioManager.GetStudios().ToList()
            };

            return View(adminViewModel);
        }

        public ActionResult UserDetails()
        {
            var adminViewModel = new AdminViewModel()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                AllUsers = _userManager.GetUsers()
            };

            return View(adminViewModel);
        }

        public ActionResult MovieDetails()
        {
            var adminViewModel = new AdminViewModel()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                AllMovies = _movieManager.GetAllMovies().ToList()
            };

            return View(adminViewModel);
        }

        public ActionResult StudioDetails()
        {
            var adminViewModel = new AdminViewModel()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                AllStudios = _studioManager.GetStudios().ToList()
            };

            return View(adminViewModel);
        }

        public ActionResult GenreDetails()
        {
            var adminViewModel = new AdminViewModel()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                AllGenres = _genreManager.GetGenres().ToList()
            };

            return View(adminViewModel);
        }

        public ActionResult RemoveAdminRole(int id)
        {
            try
            {
                _userManager.SetOrRemoveAdminRole(id, false);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }

        public ActionResult SetAdminRole(int id)
        {
            try
            {
                _userManager.SetOrRemoveAdminRole(id, true);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }
    }
}
