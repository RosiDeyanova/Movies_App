using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using Scrypt;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(MoviesContext moviesContext) : base(moviesContext)
        {
        }

        public IQueryable<User> GetUsers()
        {
            var users = Db.User
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Studio)
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Genre);

            return users;
        }

        public User GetUserById(int id)
        {
            var user = Db.User
               .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Studio)
               .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Genre)
               .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = Db.User
               .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Studio)
               .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Genre)
               .FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User GetRegisteredUser(string email, string password)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            var hashedPassword = encoder.Encode(password);
            try
            {
                var user = Db.User
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Studio)
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Genre)
                .FirstOrDefault(u => u.Email == email);

                if (encoder.Compare(password, user.Password))
                {
                    return user;
                }

                return null;
            }
            catch
            {
               return null;
            }
        }
        public void SetOrRemoveAdminRole(int id, bool isAdmin)
        {
            var user = Db.User.FirstOrDefault(x => x.Id == id);
            user.IsAdmin = isAdmin;
            SaveDb();
        }

        public void AddUser(User user)
        {
            Db.User.Add(user);
            SaveDb();
        }

        public void AddMovieToUser(int userId, int movieId)
        {
            var usermovie = new UserMovie
            {
                UserId = userId,
                MovieId = movieId,
            };
            Db.UserMovie.Add(usermovie);
            SaveDb();
        }

        public void RemoveMovieFromUser(int userId, int movieId)
        {
            var usermovie = Db.UserMovie.FirstOrDefault(u => u.MovieId == movieId && u.UserId == userId);
            Db.UserMovie.Remove(usermovie);
            SaveDb();
        }

        public List<Movie> GetMovies(int userId)
        {
            var user = GetUserById(userId);
            var movies = user.UserMovies.Select(um => um.Movie).ToList();

            return movies;
        }
    }
}
