using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Movies.Web.ViewModel.Movies;

namespace Movies.Web.ViewModel.User
{
    public class UserViewModel : LayoutViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "The repeated password is required")]
        public string RepeatedPassword { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public ICollection<CreateMovieViewModel> Movies { get; set; }
    }
}
