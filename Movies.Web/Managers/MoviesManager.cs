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

        public MoviesManager(IMovieManager movieManager)
        {
            _movieManager = movieManager;
        }

        public static MovieModel ReturnMovie(CreateMovieViewModel view)
        {
            MovieModel movie = new MovieModel
            {
                Title = view.Title,
                Year = view.Year,
                Director = view.Director,
                StudioName = view.StudioName,
                StudioAddress = view.StudioAddress,
                GenreName = view.Genre.Name
            };
            return movie;
        }
        public static StudioModel ReturnStudio(CreateMovieViewModel view)
        {
            StudioModel studio = new StudioModel
            {
                Name = view.StudioName,
                Address = view.StudioAddress
            };
            return studio;
        }
    
        public void SaveMovie(CreateMovieViewModel view)
        {
           MovieModel movie = new MovieModel();
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
