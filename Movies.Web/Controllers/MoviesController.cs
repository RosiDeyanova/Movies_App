using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoviesController(IMovieManager movieManager, IGenreManager genreManager, IUserManager userManager, IStudioManager studioManager, IWebHostEnvironment webHostEnvironment, IAuthenticationManager authenticationManager, IMapper mapper) : base(authenticationManager, mapper)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
            _userManager = userManager;
            _studioManager = studioManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("movies")]
        public ActionResult Index()
        {
            var indexMovieViewModel = new IndexMovieViewModel
            {
                Movies = _mapper.Map<ICollection<CreateMovieViewModel>>(_movieManager.GetMovies()),
                UserMovies = _mapper.Map<ICollection<CreateMovieViewModel>>(User.Movies),
                Username = User.Username,
                IsAdmin = User.IsAdmin
            };

            return View(indexMovieViewModel);
        }

        [HttpPost]
        public ActionResult Index(string searchResult)
        {
            ViewBag.Search = searchResult;

            List<MovieModel> movieModels = null;
            if (!string.IsNullOrWhiteSpace(searchResult))
            {
                movieModels = _movieManager.SearchMovies(searchResult).ToList();
            }

            var indexMovieViewModel = new IndexMovieViewModel
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
                UserMovies = _mapper.Map<ICollection<CreateMovieViewModel>>(User.Movies),
                Movies = _mapper.Map<ICollection<CreateMovieViewModel>>(movieModels),
                SearchResult = searchResult
            };

            return View(indexMovieViewModel);
        }


        public ActionResult Details(int id)
        {
            var info = _movieManager.GetMovieById(id);
            var movie = _mapper.Map<CreateMovieViewModel>(info);
            movie.IsAdmin = User.IsAdmin;
            movie.Username = User.Username;

            return View(movie);
        }

        [Authorize(Policy = "AdminRole")]
        public ActionResult Create()
        {
            var genres = _genreManager.GetGenres();
            var studios = _studioManager.GetStudios();
            CreateMovieViewModel model = new CreateMovieViewModel
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username,
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
                if (createViewModel.ImageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(createViewModel.ImageFile.FileName);
                    string fileAbsolutePath = _movieManager.GetImageAbsolutePath(fileName);
                    _movieManager.CheckImageFolder();
                    try
                    {
                        using (var fileStream = new FileStream(fileAbsolutePath, FileMode.Create))
                        {
                            await createViewModel.ImageFile.CopyToAsync(fileStream);
                        }
                        mappedMovie.Image = fileName;
                    }
                    catch (Exception)
                    {
                        //empty on purpose
                    }
                }
                _movieManager.SaveMovie(mappedMovie);
                return RedirectToAction("MovieDetails", "Admin");
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
            movie.IsAdmin = User.IsAdmin;
            movie.Username = User.Username;

            return View(movie); 
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateMovieViewModel createMovieViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedMovie = _mapper.Map<MovieModel>(createMovieViewModel);
                    mappedMovie.Id = id;
                    mappedMovie.Image = _movieManager.GetMovieImageName(id);
                    _movieManager.UpdateMovie(mappedMovie);
                    return RedirectToAction("Details", createMovieViewModel);
                }
                catch
                {
                    return View(id);
                }
            }

            return View(id);
        }

        [Authorize(Policy = "AdminRole")]
        public ActionResult Delete(int id)
        {
            try
            {
                _movieManager.DeleteMovie(id);
                return RedirectToAction("MovieDetails", "Admin");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize(Policy = "AdminRole")]
        public ActionResult Restore(int id)
        {
            try
            {
                _movieManager.RestoreMovie(id);
                return RedirectToAction("MovieDetails", "Admin");
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
