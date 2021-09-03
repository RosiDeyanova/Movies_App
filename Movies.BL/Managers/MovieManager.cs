using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> SearchMovies(string movieTitle) 
        {
            var model = _movieRepository.GetMoviesExtended().Where(x => movieTitle == null || x.Title.Contains(movieTitle)).Select(m => new Movie
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
    }
}
