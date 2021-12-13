using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Data.Entities;
using Movies.Data.Repositories;

namespace Movies.BL.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private const string _imageFolder = "uploadedImages";
        private const string _errorImage = "error.png";


        public MovieManager(IMovieRepository movieRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<MovieModel> SearchMovies(string movieTitle)
        {
            List<Movie> model = _movieRepository.GetMoviesByTitle(movieTitle).ToList();
            var mappedMovies = _mapper.Map<List<MovieModel>>(model);
            mappedMovies.ForEach(m => m.ImagePath = GetImageRelativePath(m.Image));
            return mappedMovies;
        }

        public MovieModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            var mappedMovie = _mapper.Map<MovieModel>(movie);
            mappedMovie.ImagePath = GetImageRelativePath(mappedMovie.Image);
            return mappedMovie;
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            var model = _movieRepository.GetMovies();
            var mappedMovies = _mapper.Map<List<MovieModel>>(model);
            mappedMovies.ForEach(m => m.ImagePath = GetImageRelativePath(m.Image));

            return mappedMovies;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            var model = _movieRepository.GetAllMovies();
            var mappedMovies = _mapper.Map<List<MovieModel>>(model);
            mappedMovies.ForEach(m => m.ImagePath = GetImageRelativePath(m.Image));

            return mappedMovies;
        }

        public void SaveMovie(MovieModel movieModel)
        {
            var movie = _mapper.Map<Movie>(movieModel);
            movie.Genre = null;
            movie.Studio = null;
            _movieRepository.SaveMovie(movie);
        }

        public void UpdateMovie(MovieModel movie)
        {
            var movieData = _mapper.Map<Movie>(movie);

            _movieRepository.UpdateMovie(movieData);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public void RestoreMovie(int id)
        {
            _movieRepository.RestoreMovie(id);
        }

        public string GetImageRelativePath(string imageName)
        {
            string filePath = _imageFolder + "/" + (imageName ?? _errorImage);

            return filePath;
        }

        public string GetImageAbsolutePath(string imageName)
        {
            string relativePath = GetImageRelativePath(imageName);
            string filePath = _webHostEnvironment.WebRootFileProvider.GetFileInfo(relativePath).PhysicalPath;

            return filePath;
        }

        public void CheckImageFolder() 
        {
            string path = _webHostEnvironment.WebRootFileProvider.GetFileInfo(_imageFolder).PhysicalPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public string GetMovieImageName(int id) 
        {
            return _movieRepository.GetMovieById(id).Image;
        }
    }
}
