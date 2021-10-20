using Movies.BL.Models;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.IManagers
{
    public interface IStudioManager
    {
        public IEnumerable<StudioModel> GetStudios();
        public int SaveStudio(Studio studio);
        public int GetStudioIdByName(string name);
    }
}
