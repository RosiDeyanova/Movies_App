﻿using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class GenreManager : IGenreManager
    {
        private readonly IMovieRepository _movieRepository;

        public GenreManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<GenreModel> GetGenres() 
        {
            var model = _movieRepository.GetGenres().Select(m => new GenreModel
            {
              Id = m.Id,
              Name = m.Name
            }).ToList();

            return model;
        }
    }
}