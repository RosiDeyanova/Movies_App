using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IBaseRepository _baseRepository;
        public GenreRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public IEnumerable<Genre> GetGenres()
        {
            var genres = _baseRepository.GetDb().Genre.AsEnumerable();

            return genres;
        }
    }
}
