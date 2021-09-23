using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly MoviesContext _moviesContext;

        public BaseRepository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public MoviesContext Db => _moviesContext;
    

        public MoviesContext GetDb() 
        {
            return _moviesContext;
        }

        public void SaveDb()
        {
            _moviesContext.SaveChanges();
        }
    }
}
