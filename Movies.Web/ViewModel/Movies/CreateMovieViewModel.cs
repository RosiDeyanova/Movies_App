using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.BL.Models;
using Movies.Web.ViewModel.User;

namespace Movies.Web.ViewModel.Movies
{
    public class CreateMovieViewModel : LayoutViewModel
    {
        public UserViewModel User { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a title")]
        [StringLength(40, ErrorMessage = "The title is too long")]
        [RegularExpression(@"^[A-Za-z0-9,' -]*[A-Za-z0-9,' -][A-Za-z0-9,' -]*$", ErrorMessage = "Unallowed character is being used")]
        public string Title { set; get; }

        [Required(ErrorMessage = "Enter a year")]
        [Range(1900,2022,ErrorMessage = "The year must be between 1900 and the current year")]
        //[YearValidator(ErrorMessage = "The year must be between 1900 and the current year")]
        public int Year { set; get; }

        [Required(ErrorMessage = "Enter a director name")]
        [StringLength(30, ErrorMessage = "The name is too long")]
        [RegularExpression(@"^[A-Za-z ]*[A-Za-z ][A-Za-z]*$", ErrorMessage = "The director name can only contain letters and spaces")]
        public string Director { set; get; }

        public string Image { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public StudioViewModel Studio { get; set; }

        public GenreViewModel Genre { get; set; }

        public List<GenreModel> Genres { get; set; }

        public List<StudioModel> Studios { get; set; }

        public SelectList GenreOptions => Genres != null ? new SelectList(Genres, "Id", "Name") : null;

        public SelectList StudioOptions => Studios != null ? new SelectList(Studios, "Id", "Name") : null;
    }
}
