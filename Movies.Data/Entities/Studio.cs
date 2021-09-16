using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

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

