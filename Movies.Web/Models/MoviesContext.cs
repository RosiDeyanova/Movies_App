using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Studio> Studios { set; get; }
        public DbSet<Genre> Genres { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(new Genre {Id = 1, Name = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Adventure" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, Name = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, Name = "Crime and mystery" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, Name = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 6, Name = "Historical" });

            
        }
    }
}
