using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersManager(IUserManager userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public List<UserViewModel> GetUsers()
        {
            var userModels = _userManager.GetUsers().ToList();
            var userViewModels = _mapper.Map<List<UserViewModel>>(userModels);
            return userViewModels;
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

        public void AddMovieToUser(int userId, int movieId)
        {
            _userManager.AddMovieToUser(userId, movieId);
        }
        public void RemoveMovieFromUser(int userId, int movieId)
        {
            _userManager.RemoveMovieFromUser(userId, movieId);
        }
    }
}
