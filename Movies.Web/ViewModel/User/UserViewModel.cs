using Movies.Web.ViewModel.Movies;
using System.Collections.Generic;

namespace Movies.Web.ViewModel.User
{
    public class UserViewModel : FullLayoutViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
        public ICollection<CreateMovieViewModel> Movies { get; set; }
    }
}
