using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetGenres();
        public Genre GetGenreById(int id);
        public Genre GetGenreByName(string name);
    }
}
