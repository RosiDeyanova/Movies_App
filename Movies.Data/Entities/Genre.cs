using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class Genre
    {
        [Key] public int Id { set; get; }

        [Required(ErrorMessage = "Enter a genre name")]
        [StringLength(30)]
        [Display(Name = "Genre name")]
        public string Name { set; get; }

        public List<Movie> Movies { set; get; }
    }
}
