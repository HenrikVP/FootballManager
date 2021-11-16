using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    internal class Sql
    {
        string connectionString = @"Data Source=.\SQLExpress3;Initial Catalog=FootballManagerDB;Integrated Security=True;";
        internal void ReadTeamData()
        {
            string queryString = "SELECT TeamName FROM Team;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}");
                    }
                }
            }
        }
    }
}
