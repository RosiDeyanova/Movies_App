using System.Collections.Generic;
using Movies.BL.Models;

namespace Movies.BL.IManagers
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
