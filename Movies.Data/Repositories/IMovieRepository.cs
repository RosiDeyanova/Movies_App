﻿using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies();
        public Movie GetMovieById(int id);

        public void SaveMovie(Movie movie);

        public void UpdateMovie(Movie movie);

        public void DeleteMovie(int id);
    }
}
