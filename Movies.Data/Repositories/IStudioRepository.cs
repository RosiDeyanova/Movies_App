using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public interface IStudioRepository
    {
        public int SaveStudio(Studio studio);

        public IQueryable<Studio> GetStudios();

    }
}
