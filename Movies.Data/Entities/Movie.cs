using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Movies.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public int Year { get; set; }

        public string Image { get; set; }

        public string Director { get; set; }

        public string Summary { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int StudioId { get; set; }

        public int GenreId { get; set; }

        public virtual List<UserMovie> UserMovies { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        [NotMapped]
        public List<User> Users => UserMovies.Select(um => um.User).ToList();

    }
}
