using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;

namespace Movies.Web.Controllers
{
    public class BaseController : Controller
    {
        protected new UserModel User { get; private set; }

        public BaseController(IAuthenticationManager authenticationManager)
        {
            User = authenticationManager.GetUserFromCookie();
        }
    }
}
