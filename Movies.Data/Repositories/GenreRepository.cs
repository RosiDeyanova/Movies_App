using System.Linq;
using Movies.Data.Entities;

namespace Movies.Data.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(MoviesContext moviesContext) : base (moviesContext)
        {
        }

        public IQueryable<Genre> GetGenres()
        {
            var genres = Db.Genre;

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

        public void UploadGenre(Genre genre) 
        {
            Db.Genre.Add(genre);
            SaveDb();
        }

        public void UpdateGenre(int id, string name)
        {
            try
            {
                if (id > 0 && !string.IsNullOrEmpty(name))
                {
                    var genre = GetGenreById(id);
                    genre.Name = name;
                    SaveDb();
                }
            }
            catch (System.Exception)
            {
                throw; // will throw some kind of error
            }
        }
    }
}
