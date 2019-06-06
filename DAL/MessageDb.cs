using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MessageDb
    {
        public void Add(int id, string sender, string receiver, string text, DateTime date, string title)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("INSERT INTO [Message] (Id,Sender,Receiver,Text,Date,Title) VALUES (@Id,@Sender,@Receiver,@Text,@Date,@Title)", connection);
            mySqlCommand.Parameters.AddWithValue("@Id", id);
            mySqlCommand.Parameters.AddWithValue("@Sender", sender);
            mySqlCommand.Parameters.AddWithValue("@Receiver", receiver);
            mySqlCommand.Parameters.AddWithValue("@Text", text);
            mySqlCommand.Parameters.AddWithValue("@Date", date);
            mySqlCommand.Parameters.AddWithValue("@Title", title);

            mySqlCommand.ExecuteNonQuery();
        }

        public DataTable GetMessages(string receiver)
        {
            Connection Db = new Connection();
            SqlConnection connection = new SqlConnection(Db.Connect());
            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("GetMessages", connection);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Receiver", receiver);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mySqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
