using AutoMapper;
using Movies.BL.Models;
using Movies.BL.Services;
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
            var userModels = _userRepository.GetUsers().ToList();
            //var first = _mapper.Map<UserModel>(userModels);
            var mappedModel =_mapper.Map<List<UserModel>>(userModels);
            return mappedModel;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin)
        {
            _userRepository.SetOrRemoveAdminRole(id, isAdmin);
        }

        public User MapUser(UserModel userModel) 
        {
            var user = _mapper.Map<User>(userModel);
            return user;
        }

        public void AddUser(UserModel userModel) 
        {
            var user = MapUser(userModel);
            _userRepository.AddUser(user);
        }

        public UserModel GetUserByMail(string email) 
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public void AddMovieToUser(int userId, int movieId) 
        {
            _userRepository.AddMovieToUser(userId, movieId);
        }

    }
}

