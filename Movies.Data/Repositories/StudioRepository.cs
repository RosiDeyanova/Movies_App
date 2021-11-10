using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class StudioRepository : BaseRepository, IStudioRepository
    {
        public StudioRepository(MoviesContext moviesContext) : base (moviesContext)
        {
        }

        public void UploadStudio(Studio studio)
        {
            Db.Studio.Add(studio);
            SaveDb();
        }

        public IQueryable<Studio> GetStudios()
        {
            var studios = Db.Studio;
            return studios;
        }

        public Studio GetStudioById(int id) 
        {
            var studio = Db.Studio.Where(s => s.Id == id).FirstOrDefault();
            return studio;
        }

        public Studio GetStudioByName(string name) 
        {
            var studio = Db.Studio.Where(s => s.Name == name).FirstOrDefault();
            return studio;
        }

        public void UpdateStudio(int id, string name, string address)
        {
            try
            {
                if (id > 0 && !string.IsNullOrEmpty(name))
                {
                    var studio = GetStudioById(id);
                    studio.Name = name;
                    studio.Address = address;
                    SaveDb();
                }
            }
            catch (System.Exception)
            {
                throw; // will throw some kind of error
            }
        }
    }
}
