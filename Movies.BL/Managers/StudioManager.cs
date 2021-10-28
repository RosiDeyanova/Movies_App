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

        public int SaveStudio(Studio studio) //for future development
        {
            int id;
            Studio existingStudio = _studioRepository.GetStudioByName(studio.Name);

            if (existingStudio == null)
            {
                id = _studioRepository.SaveStudio(studio);
            }
            else
            {
                id = existingStudio.Id;
            }

            return id;
        }

        public int GetStudioIdByName(string name)
        {
            var studio = _studioRepository.GetStudios().Where(x => x.Name == name).FirstOrDefault();
            return studio.Id;
        }

    }
}
