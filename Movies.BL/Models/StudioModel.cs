using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.BL.Models
{
    public class StudioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a studio name")]
        [StringLength(30, ErrorMessage = "The name is too long")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "The studio name can only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a studio address")]
        [StringLength(60, ErrorMessage ="The adress is too long")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "The studio address can only contain letters and spaces")]
        public string Address { get; set; }
    }
}
