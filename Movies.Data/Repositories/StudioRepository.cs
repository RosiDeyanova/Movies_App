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

        public void SaveStudio(Studio studio)
        {
            _moviesContext.Studios.Add(studio);
            _movieRepository.SaveDb();
        }

        public List<Studio> GetStudios()
        {
            var studios = _moviesContext.Studios.ToList();

            return studios;
        }

    }
}
