using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        public UserRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            var genres = _baseRepository.Db.User.AsEnumerable();

            return genres;
        }

        public void SetOrRemoveAdminRole(int id, bool isAdmin) 
        {
            var user = _baseRepository.Db.User.FirstOrDefault(x => x.Id == id);
            user.IsAdmin = isAdmin;
            _baseRepository.SaveDb();
        }

        public void AddUser(User user) 
        {
            _baseRepository.Db.User.Add(user);
            _baseRepository.SaveDb();
        }
    }
}
