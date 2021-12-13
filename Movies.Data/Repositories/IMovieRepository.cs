using System.Linq;
using Movies.Data.Entities;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        public IQueryable<Movie> GetMovies();

        public IQueryable<Movie> GetAllMovies();

        public Movie GetMovieById(int id);

        public IQueryable<Movie> GetMoviesByTitle(string title);

        public void SaveMovie(Movie movie);

        public void UpdateMovie(Movie movie);

        public void DeleteMovie(int id);

        public void RestoreMovie(int id);
    }
}
