using System.ComponentModel.DataAnnotations;

namespace Movies.Web.ViewModel.Movies
{
    public class StudioViewModel : LayoutViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
