using Movies.Data;
using Movies.Data.Entities;
using Movies.Web.ViewModel.Movies;
using System.Collections.Generic;
using System.Linq;

namespace Movies_App.View_Model_Manager
{
    public class IndexViewModelManager
    {
        public static Studio ReturnStudioById(MoviesContext _context, int StudioId)
        {
            var Studios = _context.Studios.ToList();
            for (int i = 0; i < Studios.Count; i++)
            {
                if (Studios[i].Id == StudioId)
                {
                    return Studios[i];
                }
            }
            return null;
        }

        public static Genre ReturnGenreById(MoviesContext _context, int GenreId)
        {
            var Genres = _context.Genres.ToList();
            for (int i = 0; i < Genres.Count; i++)
            {
                if (Genres[i].Id == GenreId)
                {
                    return Genres[i];
                }
            }
            return null;
        }

        public static IEnumerable<MoviesViewModel> ReturnMovies(MoviesContext _context)
        {
            List<MoviesViewModel> model = new List<MoviesViewModel>();
            var Movies = _context.Movies.ToList();
            foreach (var item in Movies)
            {
                MoviesViewModel temp = new MoviesViewModel();
                temp.Id = item.Id;
                temp.Title = item.Title;
                temp.Year = item.Year;
                temp.DirectorName = item.Director;
                temp.StudioName = ReturnStudioById(_context,(item.StudioId)).Name;
                temp.StudioAddress = ReturnStudioById(_context, (item.StudioId)).Address;
                temp.GenreName = ReturnGenreById(_context, (item.StudioId)).Name;
                model.Add(temp);
            }
            return model;
        }
    }
}
