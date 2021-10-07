using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.IO;
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
            var movies = _baseRepository.Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).ToList();
            return movies;
        }

        public void SaveMovie(Movie movie)
        {
            _baseRepository.Db.Movie.Add(movie);
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
        public Movie GetMovieById(int id) 
        {
            var movie = GetMovies().FirstOrDefault(m => m.Id == id);
            return movie;
        }
    }
}
