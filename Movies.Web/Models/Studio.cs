using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.Models
{
    public class Studio
    {
        [Key] public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "Enter a studio name")]
        [StringLength(30)]
        [Display(Name = "Studio name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a studio address")]
        [StringLength(30)]
        [Display(Name = "Studio address")]
        public string Address { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();


        public bool Equals(Studio other)
        {
            if (other == null)
                return false;

            return this.Name.Equals(other.Name) &&
                (
                    object.ReferenceEquals(this.Name, other.Name) ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&
                (
                    object.ReferenceEquals(this.Address, other.Address) ||
                    this.Address != null &&
                    this.Address.Equals(other.Address)
                );
        }
    }
}

