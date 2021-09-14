using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.BL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Movies.Web.ViewModel.Movies
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = "Enter a title")]
        [StringLength(40)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Title { set; get; }

        [Required(ErrorMessage ="Enter a year")]
        public int Year { set; get; }

        [Required(ErrorMessage = "Enter a director name")]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Director { set; get; }
        public StudioModel Studio { get; set; }
        public GenreModel Genre { get; set; }
        public List<GenreModel> Genres { get; set; }
        public SelectList GenreOptions => Genres != null ? new SelectList(Genres, "Id", "Name") : null;
    }
}
