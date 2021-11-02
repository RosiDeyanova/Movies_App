using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
