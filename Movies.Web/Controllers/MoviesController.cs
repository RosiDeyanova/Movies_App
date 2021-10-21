using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Web.Models;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.User;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class MoviesController : BaseController
    {
        private readonly IMovieManager _movieManager;
        private readonly IGenreManager _genreManager;
        private readonly IUserManager _userManager;
        private readonly IStudioManager _studioManager;

        public MoviesController(IMovieManager movieManager, IGenreManager genreManager, IUserManager userManager, IStudioManager studioManager, IAuthenticationManager authenticationManager, IMapper mapper) : base(authenticationManager, mapper)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
            _userManager = userManager;
            _studioManager = studioManager;
        }

        [HttpGet("movies")]
        public ActionResult Index(string searchResult)
        {
            List<MovieModel> movieModels;
            if (string.IsNullOrEmpty(searchResult))
            {
                movieModels = _movieManager.GetAllMovies().ToList();
            }
            else
            {
                movieModels = _movieManager.SearchMovies(searchResult).ToList();
            }
            var userModel = _userManager.GetUserByEmail(User.Email);

            var indexMovieViewModel = new IndexMovieViewModel 
            { 
                User = _mapper.Map<UserViewModel>(userModel),
                Movies = _mapper.Map<List<CreateMovieViewModel>>(movieModels),
                SearchResult = searchResult
            };
                       
            return View(indexMovieViewModel);
        }

        public ActionResult Details(int id)
        {
            var info = _movieManager.GetMovieById(id);
            var movie = _mapper.Map<CreateMovieViewModel>(info);
            var userModel = _userManager.GetUserByEmail(User.Email);
            var mappedUser = _mapper.Map<UserViewModel>(userModel);
            var result = new Tuple <CreateMovieViewModel, UserViewModel>(movie, mappedUser);

            return View(result);
        }

        [Authorize(Policy = "AdminRole")]
        public ActionResult Create()
        {
            var genres = _genreManager.GetGenres();
            var studios = _studioManager.GetStudios();
            CreateMovieViewModel model = new CreateMovieViewModel
            {
                Genres = _mapper.Map<List<GenreModel>>(genres),
                Studios = _mapper.Map<List<StudioModel>>(studios)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMovieViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var mappedMovie = _mapper.Map<MovieModel>(createViewModel);
                await _movieManager.SaveMovie(mappedMovie);
                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize(Policy = "AdminRole")]
        public ActionResult Edit(int id)
        {
            var info = _movieManager.GetMovieById(id);
            var genres = _genreManager.GetGenres().ToList();
            var studios = _studioManager.GetStudios().ToList();
            var movie = _mapper.Map<CreateMovieViewModel>(info);
            movie.Genres = genres;
            movie.Studios = studios;
            return View(movie); 
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateMovieViewModel createMovieViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedMovie = _mapper.Map<MovieModel>(createMovieViewModel);
                    mappedMovie.Id = id;
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

        [Authorize(Policy = "AdminRole")]
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
