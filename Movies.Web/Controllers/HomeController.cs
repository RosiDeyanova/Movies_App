﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies_App.Models;
using Movies_App.View_Model_Manager;
using Movies_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.Controllers
{
    public  class HomeController : Controller
    {
        private readonly MoviesContext _context;

        public HomeController(MoviesContext context)
        {
            _context = context;
        }

        public ActionResult Index(string movieTitle)
        {
            //var model = _context.Movies.Include(m => m.Studio).Include(k=>k.Genre).Where(x => x.Title.Contains(movieTitle) || movieTitle == null).ToList();
            var model = IndexViewModelManager.ReturnMovies(_context);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Create() 
        {
            CreateViewModel view = new CreateViewModel(_context);
            return View(view);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel createViewModel, [FromServices] CreateViewModelManager manager) 
        {
            if (ModelState.IsValid)
            {
                manager.SaveMovie(createViewModel);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Edit(int id) 
        {
            var info = _context.Movies.Where(x => x.Id == id);
            return PartialView("_Edit", info);
        }

        [HttpPost]
        public ActionResult Edit(int id, Movie movie) 
        {
            try
            {
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {

                return View();
            }
        }

        public ActionResult Delete(int id) 
        {
            return View(_context.Movies.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
                _context.Movies.Remove(movie);
                _context.SaveChanges();
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