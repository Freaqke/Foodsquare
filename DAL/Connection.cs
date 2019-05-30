using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class Connection
    {
        private string ConnectionString = "Server = mssql.fhict.local; Database = dbi301339; User Id = dbi301339; Password = YourChoosenPassword";

        public MySqlConnection Connect()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            return connection;
        }
    }
}
