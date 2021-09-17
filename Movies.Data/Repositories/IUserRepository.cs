using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public void SetOrRemoveAdminRole(int id, bool isAdmin);
    }
}
