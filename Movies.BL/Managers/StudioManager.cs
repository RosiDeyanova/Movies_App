using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;

namespace Movies.BL.Managers
{
    class StudioManager : IStudioManager
    {
        private readonly IStudioRepository _studioRepository;

        public StudioManager(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public void SaveStudio(Movie movie)
        {
            Studio studio = movie.Studio;
            List<Studio> studios = _studioRepository.GetStudios();
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
                _studioRepository.SaveStudio(studio);
            }
        }
    }
}
