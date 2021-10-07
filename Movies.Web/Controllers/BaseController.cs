using Microsoft.AspNetCore.Mvc;
using Movies.BL.Models;
using Movies.Web.Managers;

namespace Movies.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UserModel User { get; private set; }

        public BaseController(AuthenticationManager authenticationManager)
        {
            User = authenticationManager.GetUserFromCookie();
        }
    }
}
