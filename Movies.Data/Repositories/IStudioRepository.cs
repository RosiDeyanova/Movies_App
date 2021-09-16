using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IStudioRepository
    {
        public int SaveStudio(Studio studio);

        public List<Studio> GetStudios();

    }
}
