using Movies.BL.Models;

namespace Movies.BL.IManagers
{
    public interface IAuthenticationManager
    {
        public UserModel GetUserFromCookie();
    }
}
