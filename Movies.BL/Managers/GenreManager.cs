using System.Collections.Generic;
using AutoMapper;
using Movies.BL.IManagers;
using Movies.BL.Models;
using Movies.Data.Entities;
using Movies.Data.Repositories;

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

        public void UploadGenre(GenreModel genreModel) 
        {
            if (_genreRepository.GetGenreByName(genreModel.Name)==null)
            {
                Genre genre = _mapper.Map<Genre>(genreModel);
                _genreRepository.UploadGenre(genre);
            }
        }

        public GenreModel GetGenreById(int id)
        { 
            var genre = _genreRepository.GetGenreById(id);
            var genreModel = _mapper.Map<GenreModel>(genre);
            return genreModel;
        }

        public void UpdateGenre(int id, string name) 
        {
            _genreRepository.UpdateGenre(id, name);
        }
    }
}
