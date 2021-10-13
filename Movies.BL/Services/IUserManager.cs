using Movies.BL.Models;
using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.BL.Services
{
    public interface IUserManager
    {
        public List<UserModel> GetUsers();
        public void SetOrRemoveAdminRole(int id, bool isAdmin);
        public void AddUser(UserModel userModel);
        public UserModel GetUserByEmail(string email);
        public UserModel GetRegisteredUser(string email, string password);
        public void AddMovieToUser(int userId, int movieId);
        public void RemoveMovieFromUser(int userId, int movieId);

    }
}
