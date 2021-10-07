﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.Managers;
using Movies.BL.Models;
using Movies.BL.Services;
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
        private readonly IUserManager _userManager;

        public AuthenticationManager(IHttpContextAccessor httpContextAccessor, IUserManager userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public UserModel GetUserFromCookie()
        {
            var email = GetMailFromCookie();
            var user = _userManager.GetUserByEmail(email);

            return user;
        }

        private string GetMailFromCookie()
        {
            var httpContextUser = _httpContextAccessor.HttpContext.User;
            var email = httpContextUser.FindFirstValue(ClaimTypes.Email);

            return email;
        }
    }
}
