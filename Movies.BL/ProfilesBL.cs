using AutoMapper;
using Movies.BL.Models;
using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
