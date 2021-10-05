using AutoMapper;
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
        private readonly IMapper _mapper;

        public MoviesManager(IMovieManager movieManager, IGenreManager genreManager, IMapper mapper)
        {
            _movieManager = movieManager;
            _genreManager = genreManager;
            _mapper = mapper;
        }

        public MovieModel GetMovie(int id, CreateMovieViewModel view)
        {

            var movie = _mapper.Map<MovieModel>(view);
            movie.Id = id;
            return movie;
        }

        public MovieModel GetMovie(CreateMovieViewModel view)
        {
            var mappedMovie = _mapper.Map<MovieModel>(view);
            return mappedMovie;
        }

        public CreateMovieViewModel GetMovie(MovieModel model)
        {
            var genres = _genreManager.GetGenres().ToList();
            var movie = _mapper.Map<CreateMovieViewModel>(model);
            movie.Genres = genres;

            return movie;
        }
    }
}
