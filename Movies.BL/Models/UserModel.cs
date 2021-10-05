using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.BL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<MovieModel> Movies { get; set; }
    }
}
