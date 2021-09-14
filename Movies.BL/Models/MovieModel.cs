namespace Movies.BL.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public StudioModel Studio { get; set; }
        public GenreModel Genre { get; set; }
    }
}
