using AutoMapper;
using Movies.BL.Models;
using Movies.BL.Services;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class GenreManager : IGenreManager
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreManager(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public IEnumerable<GenreModel> GetGenres() 
        {
            var model = _genreRepository.GetGenres();
            var mappedModel = _mapper.Map<IEnumerable<GenreModel>>(model);

            return mappedModel;
        }

    }
}
