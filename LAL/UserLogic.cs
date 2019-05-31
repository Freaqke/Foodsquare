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

    }
}
