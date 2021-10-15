﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Managers;
using Movies.BL.IManagers;
using Movies.Web.Managers;
using Movies.Web.ViewModel.User;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper, IAuthenticationManager authenticationManager) : base (authenticationManager)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("user")]
        public ActionResult Index()
        {
            var loggedUser = _mapper.Map<UserViewModel>(User);
            return View(loggedUser);
        }

        public ActionResult AddMovie(int movieId)
        {
            var user = _userManager.GetUserByEmail(User.Email);
            _userManager.AddMovieToUser(user.Id, movieId);
            return RedirectToAction("Index","Movies");
        }

        public ActionResult RemoveMovie(int movieId)
        {
            var user = _userManager.GetUserByEmail(User.Email);
            _userManager.RemoveMovieFromUser(user.Id, movieId);
            return RedirectToAction("Index", "Movies");
        }
    }
}
