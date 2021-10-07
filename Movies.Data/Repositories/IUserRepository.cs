using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public void SetOrRemoveAdminRole(int id, bool isAdmin);
        public void AddUser(User user);
        public User GetUserById(int id);
        public User GetUserByEmail(string email);
        public void AddMovieToUser(int userId, int movieId);
        public void RemoveMovieFromUser(int userId, int movieId);

    }
}
