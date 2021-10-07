using AutoMapper;
using Movies.BL.Models;
using Movies.Data.Entities;

namespace Movies.BL
{
    public class ProfilesBL : Profile
    {
        public ProfilesBL()
        {
            CreateMap<MovieModel, Movie>().ReverseMap();
            CreateMap<StudioModel, Studio>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<GenreModel, Genre>().ReverseMap();
        }
    }
}
