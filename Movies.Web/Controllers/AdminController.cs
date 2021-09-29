using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Services;
using Movies.Web.Managers;
using Movies.Web.ViewModel.Admin;
using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly UsersManager _usersManager;
        private readonly IUserManager _userManager;

        public AdminController(UsersManager usersManager, IUserManager userManager, AuthenticationManager authenticationManager) : base (authenticationManager)
        {
            _usersManager = usersManager;
            _userManager = userManager;
        }

        [HttpGet("admin")]
        public IActionResult Index()
        {
            var users = _userManager.GetUsers();
            var adminInfo = new AdminViewModel()
            {
                Admin = User,
                AllUsers = users
            };
            return View(adminInfo);
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
                Task.Delay(10000).Wait();
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
