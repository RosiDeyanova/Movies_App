using System.ComponentModel.DataAnnotations;

namespace Movies.Web.ViewModel.Studios
{
    public class CreateStudioViewModel : LayoutViewModel
    {
        [Required(ErrorMessage = "Enter a studio name")]
        [RegularExpression(@"^[A-Za-z0-9' - ]*[A-Za-z0-9' - ][A-Za-z0-9' -]*$", ErrorMessage = "The studio name can only contain letters, numbers, spaces amnd the symbols ' -")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a studio address")]
        [RegularExpression(@"^[A-Za-z0-9',. ]*[A-Za-z0-9',. ][A-Za-z0-9',. ]*$", ErrorMessage = "The studio name can only contain letters, numbers, spaces amnd the symbols ' -")]
        public string Address { get; set; }
    }
}
