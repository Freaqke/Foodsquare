using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdvertisementDb
    {
        public void Add(string username, int available, string description)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [Advertisement] (Username,Available,Description) VALUES (@Username,@Available,@Description)", connection);
            mySqlCommand.Parameters.AddWithValue("@Username", username);
            mySqlCommand.Parameters.AddWithValue("@Available", available);
            mySqlCommand.Parameters.AddWithValue("@Description", description);

            mySqlCommand.ExecuteNonQuery();
        }
    }
}
