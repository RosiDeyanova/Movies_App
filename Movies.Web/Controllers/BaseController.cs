using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;

namespace Movies.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected new UserModel User { get; private set; }

        public BaseController(IAuthenticationManager authenticationManager, IMapper mapper)
        {
            User = authenticationManager.GetUserFromContext();
            _mapper = mapper;
        }
    }
}
