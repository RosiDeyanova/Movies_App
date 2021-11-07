using Movies.BL.Models;
using Movies.Web.ViewModel.User;
using System.Collections.Generic;

namespace Movies.Web.ViewModel.Admin
{
    public class AdminViewModel : UserViewModel
    {
        public List<UserModel> AllUsers { get; set; }
        public List<MovieModel> AllMovies { get; set; }
        public List<StudioModel> AllStudios { get; set; }
        public List<GenreModel> AllGenres { get; set; }
    }
}
