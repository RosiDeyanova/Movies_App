﻿using Movies.Data.ComplexTypes;
using Movies.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesContext _moviesContext;

        public MovieRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public List<Movie> GetMovies()
        {
            var movies = _moviesContext.Movies.ToList();

            return movies;
        }

        public List<Studio> GetStudios()
        {
            var studios = _moviesContext.Studios.ToList();

            return studios;
        }

        public IEnumerable<MovieExtended> GetMoviesExtended() 
        {
            var result = _moviesContext.Movies.Select(m => new MovieExtended
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                StudioName = m.Studio.Name,
                StudioAddress = m.Studio.Address,
                GenreName = m.Genre.Name
            }).AsEnumerable();

            return result;
        }

        //public Movie GetMovieById(int Id) 
        //{
        //    var result = _moviesContext.Movies.Where(x => x.Id == Id).FirstOrDefault();
        //    return result;
        //}

        public void SaveMovie(Movie movie)
        {
            _moviesContext.Movies.Add(movie);
            _moviesContext.SaveChanges();
        }

        public void SaveStudio(Studio studio)
        {
            _moviesContext.Studios.Add(studio);
            _moviesContext.SaveChanges();
        }
    }
}
