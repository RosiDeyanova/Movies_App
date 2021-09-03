using System.ComponentModel.DataAnnotations;

namespace Movies.Web.ViewModel.Movies
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int  Year { get; set; }
        public string DirectorName { get; set; }
        [Display(Name = "Studio name")]
        public string StudioName { get; set; }
        [Display(Name = "Studio address")]
        public string StudioAddress { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
