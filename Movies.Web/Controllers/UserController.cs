using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Web.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UsersManager _usersManager;
        public UserController(UsersManager usersManager,AuthenticationManager authenticationManager) : base (authenticationManager)
        {
            _usersManager = usersManager;
        }
        public IActionResult Index()
        {
            var loggedUser = _usersManager.MapUser(User);
            return View(loggedUser);
        }
    }
}
