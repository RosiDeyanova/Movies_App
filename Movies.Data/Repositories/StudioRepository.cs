using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private readonly MoviesContext _moviesContext;
        private readonly IMovieRepository _movieRepository;

        public StudioRepository(MoviesContext moviesContext, IMovieRepository movieRepository)
        {
            _moviesContext = moviesContext;
            _movieRepository = movieRepository;
        }

        public int SaveStudio(Studio studio)
        {
            _moviesContext.Studio.Add(studio);
            _movieRepository.SaveDb();
            return studio.Id;
        }

        public List<Studio> GetStudios()
        {
            var studios = _moviesContext.Studio.ToList();
            return studios;
        }

    }
}
