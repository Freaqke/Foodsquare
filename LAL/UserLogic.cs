using System;
using System.Data;
using DAL;


namespace LAL
{
    public class UserLogic
    {
       
        
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

         public void UserRegistration(string username, string password, string city, string zipcode, string phone, string eMail, int online, int admin)
         {
            UserDb connection = new UserDb();

            connection.Registration(username, password, city, zipcode, phone, eMail, online, admin);
         }
    }
}
