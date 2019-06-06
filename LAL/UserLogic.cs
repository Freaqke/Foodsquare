using System;
using System.Data;
using DAL;
using System.Collections.Generic;


namespace LAL
{
    public class UserLogic
    {
       public string username; 
       public string password;
       public string city;
       public string zipcode;
       public string phone;
       public string eMail;
       public int online;
       public int admin;


         public bool UserAuthentication (string username, string password)
         {
             UserDb connection = new UserDb();

             if (connection.LoginCredentials(username,password).Read())
             {
                 return true;
             }
             else
             {                
                 return false;                 
             }

         }

         public List<UserLogic> AdminVerification(string username)
         {
             UserDb connection = new UserDb();
             DataTable dataTable = connection.UserCredentials(username);
             List<UserLogic> list = new List<UserLogic>();

             foreach (DataRow dr in dataTable.Rows)
             {
                 UserLogic user = new UserLogic();          
                 user.admin = Convert.ToInt32(dr["Admin"]);
                 list.Add(user);
             }

             return list;
         }


         public void UserRegistration(string username, string password, string city, string zipcode, string phone, string eMail, int online, int admin)
         {
            UserDb connection = new UserDb();

            connection.Registration(username, password, city, zipcode, phone, eMail, online, admin);
         }
    }
}
