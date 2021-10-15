using Movies.BL.IManagers;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class StudioManager : IStudioManager
    {
        private readonly IStudioRepository _studioRepository;

        public StudioManager(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public int SaveStudio(Studio studio)
        {
            IQueryable<Studio> studios = _studioRepository.GetStudios();

            int? id = studios.FirstOrDefault(s => s.Equals(studio))?.Id;

            if (id == null)
            {
                id = _studioRepository.SaveStudio(studio);
            }

            return id.Value;
        }

        public int GetStudioIdByName(string name)
        {
            var studio = _studioRepository.GetStudios().Where(x => x.Name == name).FirstOrDefault();
            return studio.Id;
        }

    }
}
