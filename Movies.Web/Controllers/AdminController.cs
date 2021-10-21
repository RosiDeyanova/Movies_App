using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.Web.ViewModel.Admin;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class AdminController : BaseController
    {
        private readonly IUserManager _userManager;

        public AdminController(IUserManager userManager, IAuthenticationManager authenticationManager, IMapper mapper) : base (authenticationManager, mapper)
        {
            _userManager = userManager;
        }

        [HttpGet("admin")]
        public ActionResult Index()
        {
            var users = _userManager.GetUsers();
            var adminInfo = new AdminViewModel()
            {
                Id = User.Id,
                Email = User.Email,
                IsAdmin = User.IsAdmin,
                Movies = _mapper.Map<ICollection<CreateMovieViewModel>>(User.Movies),
                Password = User.Password,
                Username = User.Username,
                AllUsers = users
            };

            return View(adminInfo);
        }

        public ActionResult RemoveAdminRole(int id)
        {
            try
            {
                _userManager.SetOrRemoveAdminRole(id, false);
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
                _userManager.SetOrRemoveAdminRole(id, true);
            }
            catch
            {
                //empty for now
            }
            return RedirectToAction("Index");
        }
    }
}
