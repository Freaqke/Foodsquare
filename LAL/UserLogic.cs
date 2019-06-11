using System;
using System.Data;
using DAL;
using System.Collections.Generic;
using System.Dynamic;


namespace LAL
{
    public interface ILogin
    {
        string username { get; set; }
        string password { get; set; }

        bool UserAuthentication(string username, string password);
    }

    public interface IUserRegistration
    {
      string username { get; set; }
      string password { get; set; }
      string city { get; set; }
      string zipcode { get; set; }
      string phone { get; set; }
      string eMail { get; set; }
      int online { get; set; }
      int admin { get; set; }

     void UserRegistration(string username, string password, string city, string zipcode, string phone, string eMail, int online, int admin);
    }

    public interface IAdminVerification
    {
        List<UserLogic> AdminVerification(string username);
    }
    public class UserLogic  : ILogin, IUserRegistration
    {
       public string username { get; set; }
       public string password { get; set; }
       public string city { get; set; }
       public string zipcode { get; set; }
       public string phone { get; set; }
       public string eMail { get; set; }
       public int online { get; set; }
       public int admin { get; set; }



         public bool UserAuthentication ( string username, string password)
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
