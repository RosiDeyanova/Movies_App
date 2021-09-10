using Movies.Data.ComplexTypes;
using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies();
        public List<Studio> GetStudios();
        public IEnumerable<Genre> GetGenres();
        public IEnumerable<MovieExtended> GetMoviesExtended();
        //public Movie GetMovieById(int Id);
        public void SaveMovie(Movie movie);
        public void SaveStudio(Studio studio);
    }
}
