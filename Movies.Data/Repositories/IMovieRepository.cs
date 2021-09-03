using Movies.Data.ComplexTypes;
using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies();
        public IEnumerable<MovieExtended> GetMoviesExtended();
    }
}
