using Movies.Data.Entities;

namespace Movies.BL.IManagers
{
    public interface IStudioManager
    {
        public int SaveStudio(Studio studio);
        public int GetStudioIdByName(string name);
    }
}
