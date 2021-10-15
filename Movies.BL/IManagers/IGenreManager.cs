using Movies.BL.Models;
using System.Collections.Generic;

namespace Movies.BL.IManagers
{
    public interface IGenreManager
    {
       public IEnumerable<GenreModel> GetGenres();
    }
}
