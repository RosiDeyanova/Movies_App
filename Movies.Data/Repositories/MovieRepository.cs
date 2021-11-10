using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;

namespace Movies.Data.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
       
        public MovieRepository (MoviesContext moviesContext) : base(moviesContext)
        {
        }

        public IQueryable<Movie> GetMovies()
        {
            var movies = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).Where(m=>m.IsDeleted == false);
            return movies;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            var movies = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio);
            return movies;
        }

        public IQueryable<Movie> GetMoviesByTitle(string title) 
        {
            var movies = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).Where(m => (m.Title.ToLower().Contains(title.ToLower())) && m.IsDeleted == false);
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).FirstOrDefault(m => m.Id == id);
            return movie;
        }

        public void SaveMovie(Movie movie)
        {
            try
            {
                Db.Movie.Add(movie);
                SaveDb();
            }
            catch (Exception)
            {
                throw; // will throw some kind of error
            }
        }

        public void UpdateMovie(Movie movie) 
        {
            try
            {
                var dbMovie = GetMovieById(movie.Id);
                dbMovie.Title = movie.Title;
                dbMovie.Year = movie.Year;
                dbMovie.StudioId = movie.StudioId;
                dbMovie.GenreId = movie.GenreId;
                dbMovie.Director = movie.Director;
                dbMovie.Summary = movie.Summary;

                SaveDb();
            }
            catch (Exception)
            {
                throw; // will throw some kind of error
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = GetMovieById(id);
            try
            {
                movieToDelete.IsDeleted = true;
                SaveDb();
            }
            catch (Exception)
            {
                throw; // will throw some kind of error
            }
        }

        public void RestoreMovie(int id)
        {
            var movieDeleted = GetMovieById(id);
            try
            {
                movieDeleted.IsDeleted = false;
                SaveDb();
            }
            catch (Exception)
            {
                throw; // will throw some kind of error
            }
        }
    }
}
