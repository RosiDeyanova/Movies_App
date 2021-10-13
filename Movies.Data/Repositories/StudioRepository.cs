using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class StudioRepository : BaseRepository,IStudioRepository
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

    }
}
