using Movies.BL.Models;
using System.Collections.Generic;

namespace Movies.BL.Services
{
    public interface IMovieManager
    {
        public IEnumerable<Movie> SearchMovies(string movieTitle);
    }
}
