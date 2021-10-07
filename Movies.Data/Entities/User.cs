using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Movies.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;

        public virtual List<UserMovie> UserMovies { get; set; }
        [NotMapped]
        public List<Movie> Movies => UserMovies.Select(um => um.Movie).ToList();
        //public ICollection<UserFollower> Followers { get; set; }
        //public ICollection<UserFollower> Following { get; set; }
    }

}
