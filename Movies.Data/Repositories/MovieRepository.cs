using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
       
        public MovieRepository (MoviesContext moviesContext) : base(moviesContext)
        {
        }

        public IQueryable<Movie> GetMovies()
        {
            var movies = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio);
            return movies;
        }

        public IQueryable<Movie> GetMoviesByTitle(string title) 
        {
            var movies = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).Where(m => m.Title.ToLower().Contains(title.ToLower()));
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = Db.Movie.Include(m => m.UserMovies).Include(m => m.Genre).Include(m => m.Studio).FirstOrDefault(m => m.Id == id);
            return movie;
        }

        public void SaveMovie(Movie movie)
        {
            Db.Movie.Add(movie);
            SaveDb();
        }

        public void UpdateMovie(Movie movie) 
        {
            Db.Entry(movie).State = EntityState.Modified;
            SaveDb();
        }

        public void DeleteMovie(int id)
        {
           var movieDeleted = Db.Movie.FirstOrDefault(x => x.Id == id);
           Db.Movie.Remove(movieDeleted);
           SaveDb();
        }
    }
}
