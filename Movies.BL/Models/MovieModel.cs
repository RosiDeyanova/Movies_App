using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.BL.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public string Summary { get; set; }

        public string  Image { get; set; }

        [NotMapped]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public bool IsDeleted { set; get; } = false;

        public StudioModel Studio { get; set; }

        public GenreModel Genre { get; set; }
    }
}
