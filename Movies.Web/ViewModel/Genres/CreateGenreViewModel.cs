using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Movies.BL.Models;

namespace Movies.Web.ViewModel.Genres
{
    public class CreateGenreViewModel : LayoutViewModel
    {
        [Required(ErrorMessage = "Enter a genre name")]
        [RegularExpression(@"^[A-Za-z ]*[A-Za-z ][A-Za-z]*$", ErrorMessage = "The genre name can only contain letters and spaces")]
        public string Name { get; set; } 
    }
}
