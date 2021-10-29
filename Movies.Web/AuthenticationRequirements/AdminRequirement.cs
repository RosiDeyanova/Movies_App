using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Movies.Web.AuthenticationRequirements
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get; }
        public AdminRequirement(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }

}
