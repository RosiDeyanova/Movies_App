using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviesContext _moviesContext;

        public GenreRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = _moviesContext.Genres.AsEnumerable();

            return genres;
        }

    }
}
