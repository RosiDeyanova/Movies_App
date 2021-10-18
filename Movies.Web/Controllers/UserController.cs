using AutoMapper;
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
