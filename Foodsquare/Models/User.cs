using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LAL;

namespace Foodsquare.Models
{
    public class User
    {
        public int admin { get; set; }

        public List<User> UserList(string username)
        {
            List<User> uList = new List<User>();

            UserLogic uLogic = new UserLogic();

            List<UserLogic> uLogicList = uLogic.AdminVerification(username);

            foreach (UserLogic listObj in uLogicList)
            {
                User user = new User();
                user.admin = listObj.admin;
             
                uList.Add(user);
            }

            return uList;
        }
    }
}