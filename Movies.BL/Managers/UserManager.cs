using AutoMapper;
using Movies.BL.Models;
using Movies.BL.IManagers;
using Movies.Data.Entities;
using Movies.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserModel> GetUsers()
        {
            var users = _userRepository.GetUsers().ToList();
            var userModels =_mapper.Map<List<UserModel>>(users);
            return userModels;
        }

        public UserModel GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            var userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }

        public UserModel GetRegisteredUser(string email, string password) 
        {
            var user = _userRepository.GetRegisteredUser(email, password);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
        public void SetOrRemoveAdminRole(int id, bool isAdmin)
        {
            _userRepository.SetOrRemoveAdminRole(id, isAdmin);
        }

        public void AddUser(UserModel userModel) 
        {
            var user = _mapper.Map<User>(userModel);
            _userRepository.AddUser(user);
        }

        public void AddMovieToUser(int userId, int movieId) 
        {
            _userRepository.AddMovieToUser(userId, movieId);
        }
        public void RemoveMovieFromUser(int userId, int movieId)
        {
            _userRepository.RemoveMovieFromUser(userId, movieId);
        }
    }
}

