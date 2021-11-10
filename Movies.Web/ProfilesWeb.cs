using AutoMapper;
using Movies.BL.Models;
using Movies.Web.ViewModel.Genres;
using Movies.Web.ViewModel.Movies;
using Movies.Web.ViewModel.Studios;
using Movies.Web.ViewModel.User;

namespace Movies.Web
{
    public class ProfilesWeb : Profile
    {
        public ProfilesWeb()
        {
            CreateMap<CreateMovieViewModel, MovieModel>().ReverseMap();
            CreateMap<StudioViewModel, StudioModel>().ReverseMap();
            CreateMap<CreateStudioViewModel, StudioModel>().ReverseMap();
            CreateMap<GenreViewModel, GenreModel>().ReverseMap();
            CreateMap<CreateGenreViewModel, GenreModel>().ReverseMap();
            CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
    }
}
