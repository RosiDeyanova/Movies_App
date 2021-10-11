using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(MoviesContext moviesContext) : base (moviesContext)
        {
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = Db.Genre.AsEnumerable();

            return genres;
        }

        public Genre GetGenreById(int id) 
        {
            var genre = Db.Genre.FirstOrDefault(g => g.Id == id);
            return genre;
        }

        public Genre GetGenreByName(string name) 
        {
            var genre = Db.Genre.FirstOrDefault(g => g.Name == name);
            return genre;
        }
    }
}
