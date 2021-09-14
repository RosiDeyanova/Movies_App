using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public interface IStudioRepository
    {
        public void SaveStudio(Studio studio);
        public List<Studio> GetStudios();

    }
}
