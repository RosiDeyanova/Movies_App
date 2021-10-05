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
        private readonly IStudioManager _studioManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public MovieManager(IMovieRepository movieRepository, IStudioManager studioManager, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _studioManager = studioManager;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IEnumerable<MovieModel> SearchMovies(string movieTitle)
        {
            var model = _movieRepository.GetMovies().Where(x => movieTitle == null || x.Title.Contains(movieTitle));
            var mappedMovies = _mapper.Map<IEnumerable<MovieModel>>(model);

            return mappedMovies;
        }

        public MovieModel GetMovieById(int Id)
        {
            var movie = _movieRepository.GetMovies().FirstOrDefault(x => x.Id == Id);
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
            string filePath = Path.Combine(webRootPath, "UploadedImages",filename);
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
