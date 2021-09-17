using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }

        public virtual List<UserMovie> UserMovie { get;}

        public bool IsAdmin { get; set; }

        public User()
        {
            Summary = string.Empty;
            IsAdmin = false;
        }
    }

}
