using System;
using MySql.Data.MySqlClient;

namespace JacquelynneHeiman_Aeries.Services
{
    public class ConnectMySQL
    {
        private static MySqlConnection connection = new MySqlConnection();

        public static MySqlConnection GetConnection()
        {
            if(connection != null)
            {
                try
                {
                    connection.ConnectionString = "Persist Security Info = False;" +
                        "database=Aeries_StudentData;Server=192.168.0.95;Port=3306;" +
                        "User Id=aeries" + ";Password=Aeries2022;";

                    connection.Open();
                    System.Diagnostics.Trace.TraceInformation("Successfully Connected to Database!");
                    return connection;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.TraceInformation("Could not connect to database: " + e.Message);
                    return null;
                }
            }

            return null;
        }

        public static void Close()
        {
            connection.Close();
            System.Diagnostics.Trace.TraceInformation("Connection to Aeries_StudentData is now closed.");
        }
    }
}

