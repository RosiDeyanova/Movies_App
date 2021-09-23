namespace Movies.Web.ViewModel.Admin
{
    public class AdminViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
