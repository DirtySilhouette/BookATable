using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Users
{
    public class UsersDeleteViewModel:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }
}