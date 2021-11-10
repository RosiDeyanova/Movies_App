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

        public void UploadStudio(StudioModel studioModel)
        {
            Studio existingStudio = _studioRepository.GetStudioByName(studioModel.Name);

            if (existingStudio == null)
            {
                var studio = _mapper.Map<Studio>(studioModel);
                _studioRepository.UploadStudio(studio);
            }
        }

        public int GetStudioIdByName(string name)
        {
            var studio = _studioRepository.GetStudios().Where(x => x.Name == name).FirstOrDefault();
            return studio.Id;
        }

        public StudioModel GetStudioById(int id) 
        {
            var studio = _studioRepository.GetStudioById(id);
            var studioModel = _mapper.Map<StudioModel>(studio);
            return studioModel;
        }

        public void UpdateStudio(int id, string name, string address)
        {
            _studioRepository.UpdateStudio(id, name, address);
        }
    }
}
