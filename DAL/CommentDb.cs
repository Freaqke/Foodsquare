using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CommentDb
    {
        public void Add(int id, string sender, string text, DateTime date)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [Comment] (Id,Sender,Text,Date) VALUES (@Id,@Sender,@Text,@Date)", connection);
            mySqlCommand.Parameters.AddWithValue("@Id", id);
            mySqlCommand.Parameters.AddWithValue("@Sender", sender);
            mySqlCommand.Parameters.AddWithValue("@Text", text);
            mySqlCommand.Parameters.AddWithValue("@Date", date);

            mySqlCommand.ExecuteNonQuery();
        }
        public DataTable CommentId(int id)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("GetComments", connection);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mySqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
