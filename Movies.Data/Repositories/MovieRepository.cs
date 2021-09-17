using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesContext _moviesContext;

        public MovieRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public List<Movie> GetMovies()
        {
            var movies = _moviesContext.Movie.Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Year = m.Year,
                Studio = new Studio
                {
                    Id = m.Studio.Id,
                    Name = m.Studio.Name,
                    Address = m.Studio.Address
                },
                Genre = new Genre
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            }).ToList();

            return movies;
        }

        public void SaveMovie(Movie movie)
        {
            _moviesContext.Movie.Add(movie);
            SaveDb();
        }

        public void UpdateMovie(Movie movie) 
        {
            _moviesContext.Entry(movie).State = EntityState.Modified;
            SaveDb();
        }

        public void DeleteMovie(int id)
        {
           var movieDeleted = _moviesContext.Movie.FirstOrDefault(x => x.Id == id);
            _moviesContext.Movie.Remove(movieDeleted);
            SaveDb();
        }

        public void SaveDb() 
        {
            _moviesContext.SaveChanges();
        }
    }
}
