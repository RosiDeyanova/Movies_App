using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IStudioManager studioManager;
        private Movie movieData;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            movieData = new Movie();
        }
        public IEnumerable<MovieModel> SearchMovies(string movieTitle) 
        {
            var model = _movieRepository.GetMoviesExtended().Where(x => movieTitle == null || x.Title.Contains(movieTitle)).Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                StudioName = m.StudioName,
                StudioAddress = m.StudioAddress,
                GenreName = m.GenreName
            });

            return model;
        }

        public MovieModel GetMovieById(int Id) 
        {
            var movie = _movieRepository.GetMoviesExtended().Where(x => x.Id == Id).Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                StudioName = m.StudioName,
                StudioAddress = m.StudioAddress,
                GenreName = m.GenreName
            }).FirstOrDefault();
            return movie;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            var model = _movieRepository.GetMoviesExtended().Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                StudioName = m.StudioName,
                StudioAddress = m.StudioAddress,
                GenreName = m.GenreName
            }).ToList();

            return model;
        }

        public void SaveMovie(MovieModel movie) 
        {
            movieData.Title = movie.Title;
            movieData.Year = movie.Year;
            movieData.Director = movie.Director;
            Studio studio = new Studio();
            Genre genre = new Genre();
            studio.Name = movie.StudioName;
            studio.Address = movie.StudioAddress;
            movieData.Studio = studio;
            genre.Name = movie.GenreName;
            movieData.Genre = genre;
            _movieRepository.SaveMovie(movieData);
            studioManager.SaveStudio(movieData);
        }
    }
}
