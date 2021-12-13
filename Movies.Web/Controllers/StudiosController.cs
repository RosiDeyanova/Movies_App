using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Web.ViewModel.Studios;

namespace Movies.Web.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class StudiosController : BaseController
    {
        private readonly IStudioManager _studioManager;

        public StudiosController(IStudioManager studioManager, IAuthenticationManager authenticationManager, IMapper mapper) : base(authenticationManager, mapper)
        {
            _studioManager = studioManager;
        }

        public IActionResult Create()
        {
            CreateStudioViewModel studioModel = new CreateStudioViewModel
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username
            };

            return View(studioModel);
        }

        [HttpPost]
        public IActionResult Create(CreateStudioViewModel studioViewModel)
        {
            StudioModel studioModel = _mapper.Map<StudioModel>(studioViewModel);
            try
            {
                _studioManager.UploadStudio(studioModel);
            }
            catch
            {
                throw;
            }
            return RedirectToAction("StudioDetails", "Admin");
        }

        public IActionResult Edit(int id)
        {
            var studioModel = _studioManager.GetStudioById(id);
            var studioViewModel = _mapper.Map<CreateStudioViewModel>(studioModel);
            studioViewModel.Username = User.Username;
            studioViewModel.IsAdmin = User.IsAdmin;
            return View(studioViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateStudioViewModel studioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studioManager.UpdateStudio(id, studioViewModel.Name, studioViewModel.Address);
                }
                catch
                {

                    throw;
                }
            }

            return RedirectToAction("StudioDetails", "Admin");
        }
    }
}
