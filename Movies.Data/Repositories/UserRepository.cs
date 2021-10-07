using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMovieRepository _movieRepository;
        public UserRepository(IBaseRepository baseRepository, IMovieRepository movieRepository)
        {
            _baseRepository = baseRepository;
            _movieRepository = movieRepository;
        }

        public List<User> GetUsers()
        {
            var users = _baseRepository.Db.User
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Studio)
                .Include(u => u.UserMovies).ThenInclude(um => um.Movie).ThenInclude(m => m.Genre)
                .ToList();

            return users;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin) 
        {
            var user = _baseRepository.Db.User.FirstOrDefault(x => x.Id == id);
            user.IsAdmin = isAdmin;
            _baseRepository.SaveDb();
        }

        public void AddUser(User user) 
        {
            _baseRepository.Db.User.Add(user);
            _baseRepository.SaveDb();
        }
        public User GetUserById(int id) 
        {
            var user = GetUsers().FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByEmail(string email) 
        {
            var user = GetUsers().FirstOrDefault(u => u.Email == email);
            return user;
        }

        public void AddMovieToUser(int userId, int movieId) 
        {
            var usermovie = new UserMovie
            {
                UserId = userId,
                MovieId = movieId,
            };
            _baseRepository.Db.UserMovie.Add(usermovie);
            _baseRepository.SaveDb();
        }

        public void RemoveMovieFromUser(int userId, int movieId)
        {
             var usermovie = _baseRepository.Db.UserMovie.FirstOrDefault(u => u.MovieId == movieId && u.UserId == userId);
            _baseRepository.Db.UserMovie.Remove(usermovie);
            _baseRepository.SaveDb();
        }

        public List<Movie> GetMovies(int userId) 
        {
            var user = GetUserById(userId);
            var movies = user.UserMovies.Select(um => um.Movie).ToList();

            return movies;
        }
    }
}
