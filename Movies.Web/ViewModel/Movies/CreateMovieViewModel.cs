using Movies.Data.Entities;
using System.Collections.Generic;

namespace Movies.Web.ViewModel.Movies
{
    public class CreateMovieViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }
        public Genre Genre { get; set; }
        public List<Genre> Genres { get; }
    }
}
