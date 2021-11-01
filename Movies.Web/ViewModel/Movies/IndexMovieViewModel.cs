using System.Collections.Generic;

namespace Movies.Web.ViewModel.Movies
{
    public class IndexMovieViewModel : LayoutViewModel
    {
        public ICollection<CreateMovieViewModel> Movies { get; set; }
        public ICollection<CreateMovieViewModel> UserMovies { get; set; }
        public string SearchResult { get; set; }
    }
}
