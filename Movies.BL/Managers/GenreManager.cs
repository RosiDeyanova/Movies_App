using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class GenreManager : IGenreManager
    {
        private readonly IGenreRepository _genreRepository;

        public GenreManager(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<GenreModel> GetGenres() 
        {
            var model = _genreRepository.GetGenres().Select(m => new GenreModel
            {
              Id = m.Id,
              Name = m.Name
            }).ToList();

            return model;
        }

        public GenreModel GetGenre(MovieModel movie)
        {
            var genre = _genreRepository.GetGenres().Where(g => g.Name == movie.GenreName).Select(g => new GenreModel
            { 
                Id = g.Id,
                Name = g.Name
            }).FirstOrDefault();

            return genre;
        }
    }
}
