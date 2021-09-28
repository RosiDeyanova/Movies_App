using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Web.Managers;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UsersManager _usersManager;

        public AdminController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        [HttpGet("admin")]
        public IActionResult Index()
        {
            var users = _usersManager.GetUsers();

            return View(users);
        }

        public ActionResult RemoveAdminRole(int id)
        {
            try
            {
                _usersManager.SetOrRemoveAdminRole(id, false);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }

        public ActionResult SetAdminRole(int id)
        {
            try
            {
                _usersManager.SetOrRemoveAdminRole(id, true);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }
    }
}
