using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;

namespace Movies.BL.Managers
{
    class StudioManager : IStudioManager
    {
        private readonly IMovieRepository _movieRepository;

        public StudioManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void SaveStudio(Movie movie)
        {
            Studio studio = movie.Studio;
            List<Studio> studios = _movieRepository.GetStudios();
            bool flag = false;
            foreach (var item in studios)
            {
                if (studio.Equals(item))
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                _movieRepository.SaveStudio(studio);
            }
        }
    }
}
