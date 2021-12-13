namespace Movies.Data.Repositories
{
    public abstract class BaseRepository
    {
        private readonly MoviesContext _moviesContext;

        protected BaseRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        protected MoviesContext Db => _moviesContext;
    
        protected void SaveDb()
        {
            _moviesContext.SaveChanges();
        }
    }
}
