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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private const string imageFolder = "UploadedImages";

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
            List<Movie> model = _movieRepository.GetMoviesByTitle(movieTitle).ToList();
            var mappedMovies = _mapper.Map<List<MovieModel>>(model);
            return mappedMovies;
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

        public async Task SaveMovie(MovieModel movieModel)
        {
            var movie = _mapper.Map<Movie>(movieModel);
            movie.Genre = null;
            movie.Studio = null;
            if (movieModel.ImageFile != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(movieModel.ImageFile.FileName);
                string webRootPath = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(webRootPath, imageFolder, filename);
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await movieModel.ImageFile.CopyToAsync(fileStream);
                    }
                    movie.Image = filename;
                }
                catch (Exception)
                {
                    //empty on purpose
                }
            }

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

    }
}
