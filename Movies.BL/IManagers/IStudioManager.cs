using System.Collections.Generic;
using Movies.BL.Models;

namespace Movies.BL.IManagers
{
    public interface IStudioManager
    {
        public IEnumerable<StudioModel> GetStudios();

        public void UploadStudio(StudioModel studio);

        public int GetStudioIdByName(string name);

        public StudioModel GetStudioById(int id);

        public void UpdateStudio(int id, string name, string address);
    }
}
