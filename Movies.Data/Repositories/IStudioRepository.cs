using Movies.Data.Entities;
using System.Linq;

namespace Movies.Data.Repositories
{
    public interface IStudioRepository
    {
        public void UploadStudio(Studio studio);

        public IQueryable<Studio> GetStudios();

        public Studio GetStudioById(int id);

        public Studio GetStudioByName(string name);

        public void UpdateStudio(int id, string name, string address);
    }
}
