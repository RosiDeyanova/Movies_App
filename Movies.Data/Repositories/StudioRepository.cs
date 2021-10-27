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

        public int SaveStudio(Studio studio)
        {
            Db.Studio.Add(studio);
            SaveDb();
            return studio.Id;
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
    }
}
