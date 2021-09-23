using Movies.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.BL.Services
{
    public interface IMovieManager
    {
        public IEnumerable<MovieModel> SearchMovies(string movieTitle);
        public MovieModel GetMovieById(int Id);
        public IEnumerable<MovieModel> GetAllMovies();
        public Task SaveMovie(MovieModel movie);
        public void UpdateMovie(MovieModel movie);
        public void DeleteMovie(int id);
    }
}
