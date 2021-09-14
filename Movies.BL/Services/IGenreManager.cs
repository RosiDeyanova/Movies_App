using Movies.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.BL.Services
{
    public interface IGenreManager
    {
       public IEnumerable<GenreModel> GetGenres();
    }
}
