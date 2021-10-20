using AutoMapper;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class StudioManager : IStudioManager
    {
        private readonly IStudioRepository _studioRepository;
        private readonly IMapper _mapper;

        public StudioManager(IStudioRepository studioRepository, IMapper mapper)
        {
            _studioRepository = studioRepository;
            _mapper = mapper;
        }

        public IEnumerable<StudioModel> GetStudios()
        {
            var studios = _studioRepository.GetStudios();
            var studioModels = _mapper.Map<IEnumerable<StudioModel>>(studios);
            return studioModels;
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
