using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.ViewModel.Movies;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Web.Managers
{
    public class MoviesManager
    {
        private readonly IMovieManager _movieManager;
        private MovieModel movie;
        private StudioModel studio;

        public MoviesManager(IMovieManager movieManager)
        {
            _movieManager = movieManager;
            movie = new MovieModel();
            studio = new StudioModel();
        }

        public MovieModel ReturnMovie(CreateMovieViewModel view)
        {
            movie.Title = view.Title;
            movie.Year = view.Year;
            movie.Director = view.Director;
            movie.StudioName = view.StudioName;
            movie.StudioAddress = view.StudioAddress;
            movie.GenreName = view.Genre.Name;
            return movie;
        }
        public StudioModel ReturnStudio(CreateMovieViewModel view)
        {
            studio.Name = view.StudioName;
            studio.Address = view.StudioAddress;
            return studio;
        }
    
        public void SaveMovie(CreateMovieViewModel view)
        {
            movie = ReturnMovie(view);
            _movieManager.SaveMovie(movie);

        }
      
        public IEnumerable<MoviesViewModel> ReturnMovies()
        {
            List<MoviesViewModel> model = new List<MoviesViewModel>();
            var Movies = _movieManager.GetAllMovies();
            foreach (var item in Movies)
            {
                MoviesViewModel temp = new MoviesViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Year = item.Year,
                    DirectorName = item.Director,
                    StudioName = item.StudioName,
                    StudioAddress = item.StudioAddress,
                    GenreName = item.GenreName
                };
                model.Add(temp);
            }
            return model;
        }
    }
}
