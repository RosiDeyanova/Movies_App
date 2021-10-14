using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Movies.BL.Models;
using Movies.BL.Services;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public MovieManager(IMovieRepository movieRepository, IStudioManager studioManager, IWebHostEnvironment webHostEnvironment, IMapper mapper, IGenreManager genreManager)
        {
            _movieRepository = movieRepository;
            _studioManager = studioManager;
            _genreManager = genreManager;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IEnumerable<MovieModel> SearchMovies(string movieTitle)
        {
            if (movieTitle == null)
            {
                IEnumerable<Movie> model = _movieRepository.GetMovies().AsEnumerable();
                var mappedMovies = _mapper.Map<IEnumerable<MovieModel>>(model);
                return mappedMovies;
            }
            else
            {
                IQueryable<Movie> model = _movieRepository.GetMoviesByTitle(movieTitle);
                var mappedMovies = _mapper.Map<IQueryable<MovieModel>>(model);
                return mappedMovies;
            }
        }

        public MovieModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            var mappedMovie = _mapper.Map<MovieModel>(movie);
            return mappedMovie;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            var model = _movieRepository.GetMovies();
            var mappedMovies = _mapper.Map<IEnumerable<MovieModel>>(model);

            return mappedMovies;
        }

        public async Task SaveMovie(MovieModel movie)
        {
            Studio studioData = new Studio
            {
                Name = movie.Studio.Name,
                Address = movie.Studio.Address
            };
            int studioId = _studioManager.GetStudioIdByName(movie.Studio.Name);
            studioData.Id = studioId;

            var movieData = _mapper.Map<Movie>(movie);
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(movie.ImageFile.FileName);
            movieData.Image = filename;

            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootPath, "UploadedImages", filename);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await movie.ImageFile.CopyToAsync(fileStream);
            }

            _movieRepository.SaveMovie(movieData);
            _studioManager.SaveStudio(studioData);
        }

        public void UpdateMovie(MovieModel movie)
        {
            Studio studioData = new Studio
            {
                Id = movie.Studio.Id,
                Name = movie.Studio.Name,
                Address = movie.Studio.Address
            };

            int studioId = _studioManager.SaveStudio(studioData);
            var movieData = _mapper.Map<Movie>(movie);

            _movieRepository.UpdateMovie(movieData);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

    }
}
