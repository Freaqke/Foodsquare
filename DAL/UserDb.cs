using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class UserDb
    {
         public SqlDataReader LoginCredentials (string username, string password)
         {
             SqlConnection connection = new SqlConnection("Server = mssql.fhict.local; Database = dbi301339; User Id = dbi301339; Password = Mofo121191!");

            SqlCommand mySqlCommand = new SqlCommand("[dbo].[UserLogin]");
            mySqlCommand.Connection = connection;
            connection.Open();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Username", username);
            mySqlCommand.Parameters.AddWithValue("@Password", password);
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
        

            return mySqlDataReader;  
            
         }
    }


}
/*connection.Connect();
            connection.Connect().Open();  connection.Connect().Close();*/