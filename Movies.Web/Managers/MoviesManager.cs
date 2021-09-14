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

        public MovieModel ReturnMovie(int id)
        {
            return _movieManager.GetMovieById(id);

        }

        public MovieModel ReturnMovie(CreateMovieViewModel view)
        {
            MovieModel movie = new MovieModel
            {
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

        public CreateMovieViewModel ReturnMovie(MovieModel model)
        {
            var genres = _genreManager.GetGenres().ToList();

            CreateMovieViewModel view = new CreateMovieViewModel
            {
                Title = model.Title,
                Year = model.Year,
                Director = model.Director,
                Studio = new StudioModel
                {
                    Id = model.Studio.Id,
                    Name = model.Studio.Name,
                    Address = model.Studio.Address
                },
                Genre = new GenreModel
                {
                    Id = model.Genre.Id,
                    Name = model.Genre.Name
                },
                Genres = genres
            };

            return view;
        }

        public static StudioModel ReturnStudio(CreateMovieViewModel view)
        {
            StudioModel studio = new StudioModel
            {
                Id = view.Studio.Id,
                Name = view.Studio.Name,
                Address = view.Studio.Address
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
                    Studio = new StudioModel
                    {
                        Id = item.Studio.Id,
                        Name = item.Studio.Name,
                        Address = item.Studio.Address
                    },
                    Genre = new GenreModel()
                    {
                        Id = item.Genre.Id,
                        Name = item.Genre.Name
                    }
                };
                model.Add(temp);
            }
            return model;
        }
    }
}
