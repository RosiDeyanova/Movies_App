using System.Linq;
using Movies.Data.Entities;

namespace Movies.Data.Repositories
{
    public interface IGenreRepository
    {
        public IQueryable<Genre> GetGenres();

        public Genre GetGenreById(int id);

        public Genre GetGenreByName(string name);

        public void UploadGenre(Genre genre);

        public void UpdateGenre(int id, string name);
    }
}
