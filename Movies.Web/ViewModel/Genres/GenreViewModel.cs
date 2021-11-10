using System.ComponentModel.DataAnnotations;

namespace Movies.Web.ViewModel.Genres
{
    public class GenreViewModel : LayoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
