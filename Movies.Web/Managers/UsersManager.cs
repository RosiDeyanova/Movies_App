using Microsoft.AspNetCore.Http;
using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Web.Managers
{
    public class UsersManager
    {
        private readonly IUserManager _userManager;

        public UsersManager(IUserManager userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
        }

        public List<UserViewModel> GetUsers()
        {
            var viewModels = _userManager.GetUsers().Select(u => new UserViewModel
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

        public UserViewModel GetRegisteredUser(UserViewModel adminViewModel) 
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Email == adminViewModel.Email && u.Password == adminViewModel.Password);

            return user;
        }

        public UserModel MapUser(UserViewModel userModel) 
        {
            var usermodel = new UserModel
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                
            };
            return usermodel;
        }

        public UserViewModel MapUser(UserModel userModel)
        {
            var userViewModel = new UserViewModel
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                IsAdmin = userModel.IsAdmin
            };
            return userViewModel;
        }

        public void AddUser(UserViewModel adminViewModel) 
        {
            var userModel = MapUser(adminViewModel);
            _userManager.MapUser(userModel);
            _userManager.AddUser(userModel);
        }
    }
}
