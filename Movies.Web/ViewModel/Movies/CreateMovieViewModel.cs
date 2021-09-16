using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.BL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Movies.Web.ViewModel.Movies
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a title")]
        [StringLength(40, ErrorMessage = "The title is too long")]
        [RegularExpression(@"^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$", ErrorMessage = "The movie title can only contain letters, numbers and spaces")]
        public string Title { set; get; }

        [Required(ErrorMessage ="Enter a year")]
        [Range(1895, 2022,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Year { set; get; }

        [Required(ErrorMessage = "Enter a director name")]
        [StringLength(30, ErrorMessage = "The name is too long")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "The director name can only contain letters and spaces")]
        public string Director { set; get; }
        public StudioModel Studio { get; set; }
        public GenreModel Genre { get; set; }
        public List<GenreModel> Genres { get; set; }
        public SelectList GenreOptions => Genres != null ? new SelectList(Genres, "Id", "Name") : null;
    }
}
