using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; } = string.Empty;

        public virtual List<UserMovie> UserMovie { get; }

        //public virtual List<User> Followers { get; set; }
        //public virtual List<User> Following { get; set; }

        public bool IsAdmin { get; set; } = false;
    }

}
