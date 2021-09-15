using Movies.Data.Entities;

namespace Movies.BL.Services
{
    public interface IStudioManager
    {
        public int SaveStudio(Studio studio);
        public int GetStudioIdByName(string name);
    }
}
