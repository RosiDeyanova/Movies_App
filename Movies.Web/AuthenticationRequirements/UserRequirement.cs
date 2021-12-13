using Microsoft.AspNetCore.Authorization;

namespace Movies.Web.AuthenticationRequirements
{
    public class UserRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get; }
        public UserRequirement(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }
}
