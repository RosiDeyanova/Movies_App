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

        public IEnumerable<User> GetUsers()
        {
            //var userMovie = _baseRepository.Db.UserMovie.Include(um => um.Movie).Include(um => um.User).First();
            var users = _baseRepository.Db.User.Include(u => u.UserMovies).AsEnumerable();

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

        public void AddMovieToUser(int userId, int movieId) 
        {
            var user = GetUserById(userId);
            var movie = _movieRepository.GetMovieById(movieId);
            var usermovie = new UserMovie
            {
                UserId = user.Id,
                MovieId = movie.Id,
            };
            _baseRepository.Db.UserMovie.Add(usermovie);
            _baseRepository.SaveDb();
        }

    }
}
