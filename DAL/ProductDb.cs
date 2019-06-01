using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductDb
    {
        public void Add(string type, int amount, string weight, DateTime expiration, byte[] image, string name)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [Product] (Type,Amount,Weight,Expiration,Image,Name) VALUES (@Type,@Amount,@Weight,@Expiration,@Image,@Name)", connection);
            mySqlCommand.Parameters.AddWithValue("@Type", type);
            mySqlCommand.Parameters.AddWithValue("@Amount", amount);
            mySqlCommand.Parameters.AddWithValue("@Weight", weight);
            mySqlCommand.Parameters.AddWithValue("@Expiration", expiration);
            mySqlCommand.Parameters.AddWithValue("@Image", image);
            mySqlCommand.Parameters.AddWithValue("@Name", name);

            mySqlCommand.ExecuteNonQuery();
        }
    }
}
