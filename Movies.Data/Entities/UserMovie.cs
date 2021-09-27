using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data.Entities
{
    public class UserMovie
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
