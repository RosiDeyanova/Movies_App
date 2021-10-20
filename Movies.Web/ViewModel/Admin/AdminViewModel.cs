using Movies.BL.Models;
using Movies.Web.ViewModel.User;
using System.Collections.Generic;

namespace Movies.Web.ViewModel.Admin
{
    public class AdminViewModel : UserViewModel
    {
        public List<UserModel> AllUsers { get; set; }
    }
}
