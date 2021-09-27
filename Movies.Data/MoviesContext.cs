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
        public DbSet<UserMovie> UserMovie { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(new Genre {Id = 1, Name = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Adventure" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, Name = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, Name = "Crime and mystery" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, Name = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 6, Name = "Historical" });

            modelBuilder.Entity<User>().HasData(new User {Id = 1, Username = "admin", Email = "admin@movies.bg", Password = "1234", IsAdmin = true });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Username = "user1", Email = "user1@movies.bg", Password = "0000", IsAdmin = false });

        }
    }
}
