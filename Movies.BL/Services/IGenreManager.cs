using Movies.BL.Models;
using System.Collections.Generic;

namespace Movies.BL.Services
{
    public interface IGenreManager
    {
       public IEnumerable<GenreModel> GetGenres();
    }
}
