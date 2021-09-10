﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.BL.Services;
using Movies.Data;
using Movies.Data.Entities;
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

        public MoviesController(IMovieManager movieManager, IGenreManager genreManager)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
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
            model.Genres = _genreManager.GetGenres().Select(m => new Genre
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
               _movieManager.SaveMovie(MoviesManager.ReturnMovie(createViewModel));
                return RedirectToAction("Index");
            }


            return View();

        }

        //public ActionResult Edit(int id)
        //{
        //    var info = _context.Movies.Where(x => x.Id == id);
        //    return PartialView("_Edit", info);
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, Movie movie)
        //{
        //    try
        //    {
        //        _context.Entry(movie).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}

        //public ActionResult Delete(int id)
        //{
        //    return View(_context.Movies.Where(x => x.Id == id).FirstOrDefault());
        //}

        //[HttpPost]
        //public ActionResult Delete(int id, Movie movie)
        //{
        //    try
        //    {
        //        movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
        //        _context.Movies.Remove(movie);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
