using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        public IQueryable<Movie> GetMovies();
        public Movie GetMovieById(int id);
        public IQueryable<Movie> GetMoviesByTitle(string title);

        public void SaveMovie(Movie movie);

        public void UpdateMovie(Movie movie);

        public void DeleteMovie(int id);
    }
}
