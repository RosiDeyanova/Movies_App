using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Movies.BL.IManagers;

namespace Movies.Web.AuthenticationRequirements
{
    class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AdminRequirementHandler(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (_authenticationManager.GetUserFromContext() == null)
            {
                return Task.CompletedTask;
            }

            var isAdmin = _authenticationManager.GetUserFromContext().IsAdmin;
            if (isAdmin == true)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
