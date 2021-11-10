using Movies.BL.Models;
using System.Collections.Generic;

namespace Movies.BL.IManagers
{
    public interface IGenreManager
    {
        public IEnumerable<GenreModel> GetGenres();
        public GenreModel GetGenreById(int id);
        public void UploadGenre(GenreModel genreModel);
        public void UpdateGenre(int id, string name);
    }
}
