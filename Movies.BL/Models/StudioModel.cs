using System.ComponentModel.DataAnnotations;

namespace Movies.BL.Models
{
    public class StudioModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
