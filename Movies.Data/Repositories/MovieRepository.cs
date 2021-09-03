using Movies.Data.ComplexTypes;
using Movies.Data.Entities;
using System.Collections;
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
            var movies = _moviesContext.Movies.ToList();

            return movies;
        }

        public IEnumerable<MovieExtended> GetMoviesExtended() 
        {
            var result = _moviesContext.Movies.Select(m => new MovieExtended
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                StudioName = m.Studio.Name,
                StudioAddress = m.Studio.Address,
                GenreName = m.Genre.Name
            }).AsEnumerable();

            return result;
        }
    }
}
