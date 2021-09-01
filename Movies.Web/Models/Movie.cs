using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.Models
{
    public class Movie
    {
        [Key] public int Id { set; get; }

        
        [Required(ErrorMessage ="Enter a title")]
        [StringLength(40)]
        [Display(Name = "Movie Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Title { set; get; }
        
        [Required(ErrorMessage ="Enter a year")]
        [Display(Name = "Year")]
        public int Year { set; get; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "Enter a director name")]
        [StringLength(30)]
        [Display(Name = "Director name")]
        public string Director { set; get; }

       
        public int StudioId { set; get; }
       
        public int GenreId { set; get; }
        [ForeignKey("StudioId")]
        public virtual Studio Studio { set; get; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { set; get; }
        
    }
}
