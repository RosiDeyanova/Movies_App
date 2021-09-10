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
        private readonly IGenreManager _genreManager;

        public MoviesManager(IMovieManager movieManager, IGenreManager genreManager)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
        }

        public MovieModel ReturnMovie(int id, CreateMovieViewModel view)
        {
            MovieModel movie = new MovieModel
            {
                Id = id,
                Title = view.Title,
                Year = view.Year,
                Director = view.Director,
                StudioName = view.StudioName,
                StudioAddress = view.StudioAddress,
                GenreName = view.Genre.Name
            };
            return movie;
        }

        public MovieModel ReturnMovie(CreateMovieViewModel view)
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
        public CreateMovieViewModel ReturnMovie(MovieModel model)
        {
            var genre = _genreManager.GetGenre(model);
            var genres = _genreManager.GetGenres().ToList();

            CreateMovieViewModel view = new CreateMovieViewModel
            {
                Title = model.Title,
                Year = model.Year,
                Director = model.Director,
                StudioName = model.StudioName,
                StudioAddress = model.StudioAddress,
                Genre = genre,
                Genres = genres
            };

            return view;
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
