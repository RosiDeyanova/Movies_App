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

        public MovieManager(IMovieRepository movieRepository, IStudioManager studioManager, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _studioManager = studioManager;
            _webHostEnvironment = webHostEnvironment;

        }

        public IEnumerable<MovieModel> SearchMovies(string movieTitle)
        {
            var model = _movieRepository.GetMovies().Where(x => movieTitle == null || x.Title.Contains(movieTitle)).Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Director = m.Director,
                Studio = new StudioModel
                {
                    Id = m.Studio.Id,
                    Name = m.Studio.Name,
                    Address = m.Studio.Address
                },
                Genre = new GenreModel
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            });

            return model;
        }

        public MovieModel GetMovieById(int Id)
        {
            var movie = _movieRepository.GetMovies().Where(x => x.Id == Id).Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Image = m.Image,
                Director = m.Director,
                
                Studio = new StudioModel
                {
                    Id = m.Studio.Id,
                    Name = m.Studio.Name,
                    Address = m.Studio.Address
                },
                Genre = new GenreModel
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            }).FirstOrDefault();
            return movie;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            var model = _movieRepository.GetMovies().Select(m => new MovieModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Year = m.Year,
                Studio = new StudioModel
                {
                    Id = m.Studio.Id,
                    Name = m.Studio.Name,
                    Address = m.Studio.Address
                },
                Genre = new GenreModel
                {
                    Id = m.Genre.Id,
                    Name = m.Genre.Name
                }
            }).ToList();

            return model;
        }

        public async Task SaveMovie(MovieModel movie)
        {
            Studio studioData = new Studio
            {
                Id = movie.Studio.Id,
                Name = movie.Studio.Name,
                Address = movie.Studio.Address
            };
            int studioId = _studioManager.SaveStudio(studioData);
            Movie movieData = new Movie
            {
                Title = movie.Title,
                Year = movie.Year,
                Director = movie.Director,
                StudioId = studioId,
                GenreId = movie.Genre.Id
            };

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

            Movie movieData = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Director = movie.Director,
                StudioId = studioId,
                GenreId = movie.Genre.Id
            };

            _movieRepository.UpdateMovie(movieData);

        }

        public void DeleteMovie(int id)
        {
           _movieRepository.DeleteMovie(id);
        }
    }
}
