using Microsoft.AspNetCore.Authorization;
using Movies.BL.IManagers;
using System.Threading.Tasks;

namespace Movies.Web
{
    public class UserRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get;}
        public UserRequirement(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }
    public class AdminRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get; }
        public AdminRequirement(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }

    class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        private readonly IAuthenticationManager _authenticationManager;

        public UserRequirementHandler(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            if (_authenticationManager.GetUserFromCookie()==null)
            {
                return Task.CompletedTask;
            }

            var isAdmin = _authenticationManager.GetUserFromCookie().IsAdmin;
            if (isAdmin == false)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AdminRequirementHandler(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (_authenticationManager.GetUserFromCookie() == null)
            {
                return Task.CompletedTask;
            }

            var isAdmin = _authenticationManager.GetUserFromCookie().IsAdmin;
            if (isAdmin == true)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
