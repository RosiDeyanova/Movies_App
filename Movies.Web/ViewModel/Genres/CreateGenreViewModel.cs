using System.ComponentModel.DataAnnotations;

namespace Movies.Web.ViewModel.Genres
{
    public class CreateGenreViewModel : LayoutViewModel
    {
        [Required(ErrorMessage = "Enter a genre name")]
        [RegularExpression(@"^[A-Za-z ]*[A-Za-z ][A-Za-z]*$", ErrorMessage = "The genre name can only contain letters and spaces")]
        public string Name { get; set; } 
    }
}
