using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.Managers;
using Movies.Web.Models;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class MoviesController : BaseController
    {
        private readonly IMovieManager _movieManager;
        private readonly IGenreManager _genreManager;
        private readonly MoviesManager _moviesManager;
        private readonly IMapper _mapper;

        public MoviesController(IMovieManager movieManager, IGenreManager genreManager, MoviesManager moviesManager, AuthenticationManager authenticationManager, IMapper mapper) : base (authenticationManager)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
            _moviesManager = moviesManager;
            _mapper = mapper;
        }

        public ActionResult Index(string movieTitle)
        {
            var model = _movieManager.SearchMovies(movieTitle).ToList();
            var mappedModel = _mapper.Map<List<CreateMovieViewModel>>(model);
            var mappedUser = _mapper.Map<UserViewModel>(User);
            var result = new Tuple<List<CreateMovieViewModel>, UserViewModel>(mappedModel, mappedUser);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var info = _movieManager.GetMovieById(id);
            var mappedInfo = _moviesManager.GetMovie(info);

            return View(mappedInfo);
        }

        public ActionResult Create()
        {
            CreateMovieViewModel model = new CreateMovieViewModel
            {
                Genres = _genreManager.GetGenres().Select(m => new GenreModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMovieViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var mappedMovie = _moviesManager.GetMovie(createViewModel);
                await _movieManager.SaveMovie(mappedMovie);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var info = _movieManager.GetAllMovies().FirstOrDefault(x => x.Id == id);
            var mappedInfo = _moviesManager.GetMovie(info);

            return View(mappedInfo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateMovieViewModel createMovieViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedMovie = _moviesManager.GetMovie(id, createMovieViewModel);
                    _movieManager.UpdateMovie(mappedMovie);
                    return RedirectToAction("Details", createMovieViewModel);
                }
                return View(createMovieViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _movieManager.DeleteMovie(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
