using Movies.Data.Entities;
using System.Linq;

namespace Movies.Data.Repositories
{
    public interface IStudioRepository
    {
        public int SaveStudio(Studio studio);

        public IQueryable<Studio> GetStudios();

        public Studio GetStudioById(int id);

        public Studio GetStudioByName(string name);
    }
}
