using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Movies.BL.Models;
using Movies.BL.IManagers;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.BL.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreManager _genreManager;
        private readonly IStudioManager _studioManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private const string imageFolder = "uploadedImages";
        private const string errorImage = "error.png";


        public MovieManager(IMovieRepository movieRepository, IStudioManager studioManager, IMapper mapper, IGenreManager genreManager, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _studioManager = studioManager;
            _genreManager = genreManager;
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

        public string GetImageRelativePath(string imageName)
        {
            string filePath = imageFolder + "/" + (imageName ?? errorImage);

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
            string path = _webHostEnvironment.WebRootFileProvider.GetFileInfo(imageFolder).PhysicalPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
