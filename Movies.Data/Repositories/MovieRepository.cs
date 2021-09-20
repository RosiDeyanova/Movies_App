using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IBaseRepository _baseRepository;
        public MovieRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public List<Movie> GetMovies()
        {
            var movies = _baseRepository.GetDb().Movie.Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Year = m.Year,
                Studio = new Studio
                {
                    Id = m.Studio.Id,
                    Name = m.Studio.Name,
                    Address = m.Studio.Address
                },
                Genre = new Genre
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            }).ToList();

            return movies;
        }

        public void SaveMovie(Movie movie)
        {
            _baseRepository.GetDb().Movie.Add(movie);
            _baseRepository.SaveDb();
        }

        public void UpdateMovie(Movie movie) 
        {
            _baseRepository.GetDb().Entry(movie).State = EntityState.Modified;
            _baseRepository.SaveDb();
        }

        public void DeleteMovie(int id)
        {
           var movieDeleted = _baseRepository.GetDb().Movie.FirstOrDefault(x => x.Id == id);
           _baseRepository.GetDb().Movie.Remove(movieDeleted);
            _baseRepository.SaveDb();
        }

        
    }
}
