using Movies.BL.Models;
using Movies.BL.Services;
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
                IsAdmin = u.IsAdmin

            }).ToList();

            return userModels;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin)
        {
            _userRepository.SetOrRemoveAdminRole(id, isAdmin);
        }
    }
}

