using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.UsersData
{
    public class Users
    {
        public List<UserModel> users;

        public Users()
        {
            users = new List<UserModel>
            {
                new UserModel{ Name = "Raj", Email = "abc@gmail.com", Password = "123", MemberId = 1},
                new UserModel{ Name = "Sushil", Email = "xyz@gmail.com", Password = "123", MemberId = 2},
                new UserModel{ Name = "Jatin", Email = "lmn@gmail.com", Password = "123", MemberId = 3}
            };
        }
    }
}
