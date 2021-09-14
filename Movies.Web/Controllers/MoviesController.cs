using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.Managers;
using Movies.Web.Models;
using Movies.Web.ViewModel.Movies;
using System.Diagnostics;
using System.Linq;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieManager _movieManager;
        private readonly IGenreManager _genreManager;
        private readonly MoviesManager _moviesManager;

        public MoviesController(IMovieManager movieManager, IGenreManager genreManager, MoviesManager moviesManager)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
            _moviesManager = moviesManager;
        }

        public ActionResult Index(string movieTitle)
        {
            var model = _movieManager.SearchMovies(movieTitle);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var info = _movieManager.GetMovieById(id);
            return View(info);
        }

        public ActionResult Create()
        {
            CreateMovieViewModel model = new CreateMovieViewModel();
            model.Genres = _genreManager.GetGenres().Select(m => new GenreModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList(); ;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateMovieViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
               _movieManager.SaveMovie(_moviesManager.ReturnMovie(createViewModel));
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var info = _movieManager.GetAllMovies().Where(x => x.Id == id).FirstOrDefault();
            var mappedInfo = _moviesManager.ReturnMovie(info);
            return View(mappedInfo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateMovieViewModel createMovieViewModel)
        {
            try
            {
                _movieManager.UpdateMovie(_moviesManager.ReturnMovie(id, createMovieViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    return View(_context.Movies.Where(x => x.Id == id).FirstOrDefault());
        //}

        public ActionResult Delete(int id,CreateMovieViewModel movie)
        {
            try
            {
                _movieManager.DeleteMovie(_moviesManager.ReturnMovie(id,movie));
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
