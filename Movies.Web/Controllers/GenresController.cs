using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Web.ViewModel.Genres;

namespace Movies.Web.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class GenresController : BaseController
    {
        private readonly IGenreManager _genreManager;

        public GenresController(IGenreManager genreManager, IAuthenticationManager authenticationManager, IMapper mapper) : base(authenticationManager, mapper)
        {
            _genreManager = genreManager;
        }

        public IActionResult Create()
        {
            CreateGenreViewModel genreModel = new()
            {
                IsAdmin = User.IsAdmin,
                Username = User.Username
            };

            return View(genreModel);
        }

        [HttpPost]
        public IActionResult Create(CreateGenreViewModel genreViewModel)
        {
            GenreModel genreModel = _mapper.Map<GenreModel>(genreViewModel);
            try
            {
                _genreManager.UploadGenre(genreModel);
            }
            catch
            {
                throw;
            }
            return RedirectToAction("GenreDetails","Admin");
        }

        public IActionResult Edit(int id)
        {
            var genreModel = _genreManager.GetGenreById(id);
            var genreViewModel = _mapper.Map<CreateGenreViewModel>(genreModel);
            genreViewModel.IsAdmin = User.IsAdmin;
            genreViewModel.Username = User.Username;

            return View(genreViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateGenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _genreManager.UpdateGenre(id, genreViewModel.Name);
                }
                catch
                {
                    throw;
                }
            }

            return RedirectToAction("GenreDetails", "Admin");
        }
    }
}
