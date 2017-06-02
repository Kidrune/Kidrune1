using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerAppSharingPlatform.Dal.Data
{
    public static class Database
    {
        public const string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi365493;User ID=dbi365493;Password=Blegvrijca5";
        public static SqlCommand command;

        public static SqlConnection connection;

        public static SqlConnection OpenConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}