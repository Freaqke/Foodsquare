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
            Connection db = new Connection();
            SqlConnection connection = new SqlConnection(db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [Advertisement] (Username,Available,Description) VALUES (@Username,@Available,@Description)", connection);
            mySqlCommand.Parameters.AddWithValue("@Username", username);
            mySqlCommand.Parameters.AddWithValue("@Available", available);
            mySqlCommand.Parameters.AddWithValue("@Description", description);

            mySqlCommand.ExecuteNonQuery();
        }

        public DataTable AdvertisementInformation()
        {
            Connection db = new Connection();
            SqlConnection connection = new SqlConnection(db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("GetAllAdvertisement", connection);
            mySqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mySqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable AdvertisementId(int id)
        {
            Connection db = new Connection();
            SqlConnection connection = new SqlConnection(db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("GetAdvertisement", connection);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mySqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
