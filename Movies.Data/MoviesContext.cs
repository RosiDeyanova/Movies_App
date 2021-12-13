using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;

namespace Movies.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { set; get; }

        public DbSet<Studio> Studio { set; get; }

        public DbSet<Genre> Genre { set; get; }

        public DbSet<User> User { set; get; }

        public DbSet<UserMovie> UserMovie { set; get; }

    }
}
