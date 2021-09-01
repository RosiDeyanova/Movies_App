using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_App.ViewModel
{
    public class CreateViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }
        public Genre Genre { get; set; }
        public List<Genre> Genres { get; }

        public CreateViewModel() 
        {
            Title = "Unknown";
            Year = 0;
            Director = "Unknown";
            StudioName = "Unknown";
            StudioAddress = "Unknown";
            Genre = new Genre();
            Genre.Name = "Unknown";
            Genre.Id = 0;
            Genres = new List<Genre>();          
        }
        public CreateViewModel(MoviesContext _context) 
        {
            this.Genres = _context.Genres.ToList();
        }
    }
}
