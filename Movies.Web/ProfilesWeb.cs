using AutoMapper;
using Movies.BL.Models;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.User;

namespace Movies.Web
{
    public class ProfilesWeb : Profile
    {
        public ProfilesWeb()
        {
            CreateMap<CreateMovieViewModel, MovieModel>().ReverseMap();
            CreateMap<StudioViewModel, StudioModel>().ReverseMap();
            CreateMap<GenreViewModel, GenreModel>().ReverseMap();
            CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
    }
}
