using Movies.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.BL.Services
{
    public interface IUserManager
    {
        public List<UserModel> GetUsers();
        public void SetOrRemoveAdminRole(int id, bool isAdmin);
    }
}
