using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { set; get; }

        //[Required(ErrorMessage ="Enter a title")]
        //[StringLength(40)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Title { set; get; }
        
        //[Required(ErrorMessage ="Enter a year")]
        public int Year { set; get; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        //[Required(ErrorMessage = "Enter a director name")]
        //[StringLength(30)]
        public string Director { set; get; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { set; get; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { set; get; }
    }
}
