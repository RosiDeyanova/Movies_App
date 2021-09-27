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
                Password = u.Password,
                IsAdmin = u.IsAdmin
            }).ToList();

            return viewModels;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin) 
        {
            _userManager.SetOrRemoveAdminRole(id, isAdmin);
        }

        public Tuple<bool,int> IsUserRegistered(AdminViewModel adminViewModel) 
        {
            var user = GetUsers().Where(u => u.Email == adminViewModel.Email && u.Password == adminViewModel.Password).FirstOrDefault();
            if (user != null)
            {
                return new Tuple<bool,int>(true, user.Id);
            }
            return new Tuple<bool, int>(false, 0);
        }

        public UserModel MapUser(AdminViewModel adminViewModel) 
        {
            var usermodel = new UserModel
            {
                Username = adminViewModel.Username,
                Password = adminViewModel.Password,
                Email = adminViewModel.Username
            };
            return usermodel;
        }

        public void AddUser(AdminViewModel adminViewModel) 
        {
            var userModel = MapUser(adminViewModel);
            _userManager.MapUser(userModel);
            _userManager.AddUser(userModel);
        }
    }
}
