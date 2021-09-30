﻿using System.Collections.Generic;
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
        public bool IsAdmin { get; set; } = false;


        public ICollection<UserMovie> AddedMovies { get; set; }
        public ICollection<Follower> Followers { get; set; }
        //public ICollection<Follower> Users { get; set; }
    }

}
