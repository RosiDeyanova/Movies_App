using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Movies.BL.IManagers;
using Movies.BL.Models;

namespace Movies.BL.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserManager _userManager;

        public AuthenticationManager(IHttpContextAccessor httpContextAccessor, IUserManager userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public UserModel GetUserFromContext()
        {
            var email = GetMailFromContext();
            var user = _userManager.GetUserByEmail(email);

            return user;
        }

        private string GetMailFromContext()
        {
            var httpContextUser = _httpContextAccessor.HttpContext.User;
            var email = httpContextUser.FindFirstValue(ClaimTypes.Email);

            return email;
        }
    }
}
