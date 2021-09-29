using Movies.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.ViewModel.Admin
{
    public class AdminViewModel
    {
        public UserModel Admin { get; set; }
        public List<UserModel> AllUsers { get; set; }
    }
}
