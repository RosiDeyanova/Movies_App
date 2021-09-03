namespace Movies.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }
        public string GenreName { get; set; }
    }
}
