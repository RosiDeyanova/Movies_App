using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public void SetOrRemoveAdminRole(int id, bool isAdmin);
        public void AddUser(User user);
        public User GetUserById(int id);
        public void AddMovieToUser(int userId, int movieId);
    }
}
