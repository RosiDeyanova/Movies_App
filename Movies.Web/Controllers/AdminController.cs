using Microsoft.AspNetCore.Mvc;
using Movies.Web.Managers;

namespace Movies.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UsersManager _usersManager;

        public AdminController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var users = _usersManager.GetUsers();

            return View(users);
        }

        public ActionResult RemoveAdminRole(int id)
        {
            try
            {
                _usersManager.SetOrRemoveRole(id, false);
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
                _usersManager.SetOrRemoveRole(id, true);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }
    }
}
