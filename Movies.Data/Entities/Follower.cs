using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Movies.Data.Entities
{
    public class Follower
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int FollowerId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
        [ForeignKey("FollowerId")]

        public virtual User UserFollower { get; set; }

    }
}
