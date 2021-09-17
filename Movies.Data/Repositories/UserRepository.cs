using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MoviesContext _moviesContext;

        public UserRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public IEnumerable<User> GetUsers()
        {
            var genres = _moviesContext.User.AsEnumerable();

            return genres;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin) 
        {
            var user = _moviesContext.User.FirstOrDefault(x => x.Id == id);
            user.IsAdmin = isAdmin;
            SaveDb();
        }

        public void SaveDb()
        {
            _moviesContext.SaveChanges();
        }
    }
}
