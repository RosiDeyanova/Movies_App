using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Movies.BL.IManagers;

namespace Movies.Web.AuthenticationRequirements
{
    class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        private readonly IAuthenticationManager _authenticationManager;

        public UserRequirementHandler(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            if (_authenticationManager.GetUserFromContext() == null)
            {
                return Task.CompletedTask;
            }

            var isAdmin = _authenticationManager.GetUserFromContext().IsAdmin;
            if (isAdmin == false)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
