using System.Linq;
using Movies.Data.Entities;

namespace Movies.Data.Repositories
{
    public interface IUserRepository
    {
        public IQueryable<User> GetUsers();

        public void SetOrRemoveAdminRole(int id, bool isAdmin);

        public void AddUser(User user);

        public User GetUserById(int id);

        public User GetUserByEmail(string email);

        public User GetRegisteredUser(string email, string password);

        public void AddMovieToUser(int userId, int movieId);

        public void RemoveMovieFromUser(int userId, int movieId);
    }
}
