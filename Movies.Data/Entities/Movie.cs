using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { set; get; }

        public string Title { set; get; }
        
        public int Year { set; get; }

        public string Director { set; get; }

        public int StudioId { set; get; }

        public int GenreId { set; get; }

        public virtual List<UserMovie> UserMovie { set; get; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { set; get; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { set; get; }
    }
}
