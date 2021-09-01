using Movies_App.Models;
using Movies_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public static IEnumerable<IndexViewModel> ReturnMovies(MoviesContext _context)
        {
            List<IndexViewModel> model = new List<IndexViewModel>();
            var Movies = _context.Movies.ToList();
            foreach (var item in Movies)
            {
                IndexViewModel temp = new IndexViewModel();
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
