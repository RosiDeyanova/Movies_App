using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
//using System.Data.Entity;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // modelBuilder.Entity<UserMovie>()
           //.HasOne(p => p.User)
           //.WithMany(b => b.UserMovies)
           //.HasForeignKey("UserId");

           // modelBuilder.Entity<UserMovie>()
           //.HasOne(p => p.Movie)
           //.WithMany(b => b.UserMovies)
           //.HasForeignKey("MovieId");

            //modelBuilder.Entity<Follower>()
            //        .HasOne(u => u.User).WithMany(u => u.Followers).IsRequired().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Follower>()
            //     .HasOne(u => u.User).WithMany(u => u.Users).IsRequired().OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<Follower>()
            //    .HasKey(f => f.Id);
            //modelBuilder.Entity<Follower>()
            //    .HasOne(f => f.User)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(f => f.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Follower>()
            //    .HasOne(f => f.UserFollower)
            //    .WithMany(u => u.Followers)
            //    .HasForeignKey(f => f.FollowerId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>()
            //    .HasMany(uf => uf.Followers)
            //    .WithOne(f => f.UserFollower)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<User>()
            //    .HasMany(uf => uf.Users)
            //    .WithOne(f => f.User)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UserFollower>()
            //    .HasKey(k => new { k.UserId, k.FollowerId });
            //modelBuilder.Entity<UserFollower>()
            //    .HasOne(f => f.User)
            //    .WithMany(u => u.Followers)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<UserFollower>()
            //    .HasOne(f => f.Follower)
            //    .WithMany(u => u.Following)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserFollower>(entity =>
            //{
            //    entity.HasOne(d => d.User)
            //            .WithMany(p => p.Followers)
            //            .HasForeignKey(d => d.UserId)
            //            .OnDelete(DeleteBehavior.Cascade);
            //    //.HasConstraintName("FK_Account_Language");

            //    entity.HasOne(d => d.Follower)
            //            .WithMany(p => p.Followers)
            //            .HasForeignKey(d => d.FollowerId)
            //            .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Followers).WithMany(x => x.Following)
            //    .Map(x => x.ToTable("Followers")
            //        .MapLeftKey("UserId")
            //        .MapRightKey("FollowerId"));



            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 1, Name = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Adventure" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, Name = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, Name = "Crime and mystery" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, Name = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 6, Name = "Historical" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", Email = "admin@movies.bg", Password = "1234", IsAdmin = true });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Username = "user1", Email = "user1@movies.bg", Password = "0000", IsAdmin = false });
        }
    }
}
