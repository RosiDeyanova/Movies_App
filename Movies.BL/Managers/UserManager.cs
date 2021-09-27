using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.BL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserModel> GetUsers()
        {
            var userModels = _userRepository.GetUsers().Select(u => new UserModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Password = u.Password,
                IsAdmin = u.IsAdmin

            }).ToList();

            return userModels;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin)
        {
            _userRepository.SetOrRemoveAdminRole(id, isAdmin);
        }

        public User MapUser(UserModel userModel) 
        {
            var user = new User 
            { 
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Password
            };
            return user;
        }

        public void AddUser(UserModel userModel) 
        {
            var user = MapUser(userModel);
            _userRepository.AddUser(user);
        }

    }
}

