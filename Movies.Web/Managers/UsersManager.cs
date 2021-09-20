using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Managers
{
    public class UsersManager
    {
        private readonly IUserManager _userManager;

        public UsersManager(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public List<AdminViewModel> GetUsers()
        {
            var viewModels = _userManager.GetUsers().Select(u => new AdminViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                IsAdmin = u.IsAdmin
            }).ToList();

            return viewModels;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin) 
        {
            _userManager.SetOrRemoveAdminRole(id, isAdmin);
        }
    }
}
