using Movies.BL.Managers;
using Movies.Data;
using Movies.Data.Entities;
using Movies.Web.Managers;
using Movies.Web.ViewModel.Movies;

namespace Movies_App.View_Model_Manager
{
    public class CreateViewModelManager
    {
        private readonly MoviesContext _context;
        private Movie movie;
        private Studio studio;
        private Genre genre;
        public CreateViewModelManager(MoviesContext context)
        {
            movie = new Movie();
            genre = new Genre();
            studio = new Studio();
            _context = context;
        }

        public Movie ReturnMovie(CreateMovieViewModel view)
        {
            movie.Title = view.Title;
            movie.Year = view.Year;
            movie.Director = view.Director;
            movie.Studio = ReturnStudio(view);
            movie.Genre = ReturnGenre(view);
            return movie;
        }
        public Studio ReturnStudio(CreateMovieViewModel view)
        {
            studio.Name = view.StudioName;
            studio.Address = view.StudioAddress;
            return studio;
        }
        public Genre ReturnGenre(CreateMovieViewModel view)
        {
            genre.Name = view.Genre.Name;
            return genre;
        }

        public void SaveMovie(MoviesManager view)
        {
            movie = ReturnMovie(view);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void SaveStudio(CreateMovieViewModel view)
        {
            studio = ReturnStudio(view);
            foreach (var item in _context.Studios)
            {
                if (studio.Equals(item))
                {
                    _context.Studios.Add(studio);
                    _context.SaveChanges();
                }
            }
        }
    }
}
