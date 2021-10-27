using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.Web.ViewModel.User;

namespace Movies.Web.Controllers
{
    [Authorize(Policy = "UserRole")]
    public class UserController : BaseController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager, IAuthenticationManager authenticationManager, IMapper mapper) : base (authenticationManager, mapper)
        {
            _userManager = userManager;
        }

        [HttpGet("user")]
        public ActionResult Index()
        {
            var loggedUser = _mapper.Map<UserViewModel>(User);
            return View(loggedUser);
        }

        public ActionResult AddMovie(int movieId)
        {
            _userManager.AddMovieToUser(User.Id, movieId);
            return RedirectToAction("Index","Movies");
        }

        public ActionResult RemoveMovie(int movieId)
        {
            _userManager.RemoveMovieFromUser(User.Id, movieId);
            return RedirectToAction("Index", "Movies");
        }
    }
}
