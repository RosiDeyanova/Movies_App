using Movies.Web.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.ViewModel.Movies
{
    public class IndexMovieViewModel
    {
        public UserViewModel User { get; set; }
        public List<CreateMovieViewModel> Movies { get; set; }
        public string SearchResult { get; set; }
    }
}
