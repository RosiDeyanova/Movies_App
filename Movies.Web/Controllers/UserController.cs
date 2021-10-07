using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Managers;
using Movies.BL.Services;
using Movies.Web.Managers;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UsersManager _usersManager;
        private readonly IUserManager _userManager;
        public UserController(UsersManager usersManager,AuthenticationManager authenticationManager, IUserManager userManager) : base (authenticationManager)
        {
            _usersManager = usersManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var loggedUser = _usersManager.MapUser(User);
            return View(loggedUser);
        }
        public ActionResult AddMovie(int id)
        {
            var user = _userManager.GetUserByEmail(User.Email);
            _usersManager.AddMovieToUser(user.Id, id);
            return RedirectToAction("Index","Movies");
        }
        public ActionResult RemoveMovie(int id)
        {
            var user = _userManager.GetUserByEmail(User.Email);
            _usersManager.RemoveMovieFromUser(user.Id, id);
            return RedirectToAction("Index", "Movies");
        }
    }
}
