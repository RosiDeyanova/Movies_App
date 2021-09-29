using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movies.Web.Managers
{
    public class AuthenticationManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UsersManager _usersManager;

        public AuthenticationManager(IHttpContextAccessor httpContextAccessor, UsersManager usersManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _usersManager = usersManager;
        }
        public UserModel GetUserFromCookie()
        {
            var email = GetMailFromCookie();
            var users = _usersManager.GetUsers();
            var userWithEmail = users.FirstOrDefault(u => u.Email == email);
            var mappedUser = _usersManager.MapUser(userWithEmail);
            return mappedUser;
        }

        private string GetMailFromCookie()
        {
            var httpContextUser = _httpContextAccessor.HttpContext.User;
            var email = httpContextUser.FindFirstValue(ClaimTypes.Email);
            return email;
        }
    }
}
