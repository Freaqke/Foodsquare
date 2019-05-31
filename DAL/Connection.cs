using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class Connection
    {
        private string ConnectionString = "Server = mssql.fhict.local; Database = dbi301339; User Id = dbi301339; Password = Mofo121191!";

        public string Connect()
        {
            return ConnectionString;
        }
    }
}
