using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace DAL
{
    public class UserDb
    {
        public SqlDataReader LoginCredentials(string username, string password)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("[dbo].[UserLogin]", connection);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Username", username);
            mySqlCommand.Parameters.AddWithValue("@Password", password);
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            return mySqlDataReader;

        }

        public void Registration(string username, string password, string city, string zipcode, string phone, string eMail, int online, int admin)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [USER] (Username,Password,City,Zipcode,Phone,Email,Online,Admin) VALUES (@Username,@Password,@City,@Zipcode,@Phone,@Email,@Online,@Admin)",connection);
            mySqlCommand.Parameters.AddWithValue("@Username", username);
            mySqlCommand.Parameters.AddWithValue("@Password", password);
            mySqlCommand.Parameters.AddWithValue("@City", city);
            mySqlCommand.Parameters.AddWithValue("@Zipcode", zipcode);
            mySqlCommand.Parameters.AddWithValue("@Phone", phone);
            mySqlCommand.Parameters.AddWithValue("@Email", eMail);
            mySqlCommand.Parameters.AddWithValue("@Online", online);
            mySqlCommand.Parameters.AddWithValue("@Admin", admin);
            mySqlCommand.ExecuteNonQuery();
        }

    }
}
