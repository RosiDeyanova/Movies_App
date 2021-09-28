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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersManager(IUserManager userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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

        public UserModel MapUser(UserViewModel adminViewModel) 
        {
            var usermodel = new UserModel
            {
                Username = adminViewModel.Username,
                Password = adminViewModel.Password,
                Email = adminViewModel.Email,
                
            };
            return usermodel;
        }

        public void AddUser(UserViewModel adminViewModel) 
        {
            var userModel = MapUser(adminViewModel);
            _userManager.MapUser(userModel);
            _userManager.AddUser(userModel);
        }

        public string ReturnMailFromCookie() 
        {
            var httpContextUser = _httpContextAccessor.HttpContext.User;
            var email = httpContextUser.FindFirstValue(ClaimTypes.Email);
            return email;
        }

        public UserViewModel ReturnUserFromCookie() 
        {
            var email = ReturnMailFromCookie();
            var users = GetUsers();
            var userWithEmail = users.FirstOrDefault(u => u.Email == email);
            return userWithEmail;

        }
    }
}
