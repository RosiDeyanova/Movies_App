using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public interface IBaseRepository
    {
        public MoviesContext GetDb();
        public void SaveDb();
    }
}
