using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private readonly IBaseRepository _baseRepository;
        public StudioRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int SaveStudio(Studio studio)
        {
            _baseRepository.GetDb().Studio.Add(studio);
            _baseRepository.SaveDb();
            return studio.Id;
        }

        public List<Studio> GetStudios()
        {
            var studios = _baseRepository.GetDb().Studio.ToList();
            return studios;
        }

    }
}
