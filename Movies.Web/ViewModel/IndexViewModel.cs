using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.ViewModel
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int  Year { get; set; }
        public string DirectorName { get; set; }
        [Display(Name = "Studio name")]
        public string StudioName { get; set; }
        [Display(Name = "Studio address")]
        public string StudioAddress { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

       
    }
}
