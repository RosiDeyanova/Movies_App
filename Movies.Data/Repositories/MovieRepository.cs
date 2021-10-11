using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class MovieRepository : BaseRepository,IMovieRepository
    {
        private readonly IBaseRepository _baseRepository;
       
        public MovieRepository(IBaseRepository baseRepository, MoviesContext moviesContext) : base(moviesContext)
        {
            _baseRepository = baseRepository;
        }

        public List<Movie> GetMovies()
        {
            var movies = _baseRepository.Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).ToList();
            return movies;
        }
        public List<Movie> GetMoviesByTitle(string title) 
        {
            var movies = _baseRepository.Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).Where(m => m.Title.Contains(title)).ToList();
            return movies;
        }
        public Movie GetMovieById(int id)
        {
            var movie = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).FirstOrDefault(m => m.Id == id);
            return movie;
        }
        public void SaveMovie(Movie movie)
        {
            _baseRepository.Db.Movie.Add(movie);
            _baseRepository.SaveDb();
        }

        public void UpdateMovie(Movie movie) 
        {
            _baseRepository.Db.Entry(movie).State = EntityState.Modified;
            _baseRepository.SaveDb();
        }

        public void DeleteMovie(int id)
        {
           var movieDeleted = _baseRepository.Db.Movie.FirstOrDefault(x => x.Id == id);
           _baseRepository.Db.Movie.Remove(movieDeleted);
            _baseRepository.SaveDb();
        }
    }
}
