using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Web.ViewModel.Movies;
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

        public MovieModel GetMovie(int id, CreateMovieViewModel view)
        {
            MovieModel movie = new MovieModel
            {
                Id = id,
                Title = view.Title,
                Year = view.Year,
                Director = view.Director,
                Studio = new StudioModel
                {
                    Id = view.Studio.Id,
                    Name = view.Studio.Name,
                    Address = view.Studio.Address
                }
                ,
                Genre = new GenreModel 
                { 
                    Id = view.Genre.Id,
                    Name = view.Genre.Name
                }
            };
            return movie;
        }

        public MovieModel GetMovie(CreateMovieViewModel view)
        {
            MovieModel movie = new MovieModel
            {
                Id = view.Id,
                Title = view.Title,
                Year = view.Year,
                Director = view.Director,
                Studio = new StudioModel
                {
                    Id = view.Studio.Id,
                    Name = view.Studio.Name,
                    Address = view.Studio.Address
                },
                Genre = new GenreModel()
                {
                    Id = view.Genre.Id,
                    Name = view.Genre.Name
                }
            };
            return movie;
        }

        public CreateMovieViewModel GetMovie(MovieModel model)
        {
            var genres = _genreManager.GetGenres().ToList();

            CreateMovieViewModel view = new CreateMovieViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Year = model.Year,
                Director = model.Director,
                Studio = new StudioViewModel
                {
                    Id = model.Studio.Id,
                    Name = model.Studio.Name,
                    Address = model.Studio.Address
                },
                Genre = new GenreViewModel
                {
                    Id = model.Genre.Id,
                    Name = model.Genre.Name
                },
                Genres = genres
            };

            return view;
        }
    }
}
