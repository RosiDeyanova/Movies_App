using System.Collections.Generic;
using Movies.BL.Models;

namespace Movies.BL.IManagers
{
    public interface IMovieManager
    {
        public IEnumerable<MovieModel> SearchMovies(string movieTitle);
        public MovieModel GetMovieById(int Id);
        public IEnumerable<MovieModel> GetMovies();
        public IEnumerable<MovieModel> GetAllMovies();
        public void SaveMovie(MovieModel movie);
        public void UpdateMovie(MovieModel movie);
        public void DeleteMovie(int id);
        public void RestoreMovie(int id);
        public string GetImageRelativePath(string imageName);
        public string GetImageAbsolutePath(string imageName);
        public void CheckImageFolder();
        public string GetMovieImageName(int id);
    }
}
