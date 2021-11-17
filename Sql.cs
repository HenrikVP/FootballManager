using System.Data;
using System.Data.SqlClient;

namespace FootballManager
{
    internal class Sql
    {
        //Vores forbindelsesstreng til databasen. OBS!!! Bør ikke være her. Specielt ikke 
        //hvis der står brugernavn og password (f.eks på github kan alle se den.)
        private string connectionString = @"Data Source=.\SQLExpress3;Initial Catalog=FootballManagerDB;Integrated Security=True;";
        internal List<Team> ReadTeamData()
        {
            List<Team> teams = new();
            string queryString = "SELECT Id, TeamName FROM Team;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(new Team() { 
                                Id = (int)reader[0], 
                                Name = reader[1].ToString() 
                            });
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Ups. SQL Error: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ups. Error: " + e.Message);
                }
            }
            return teams;
        }

        internal List<Player> ReadPlayerData()
        {
            List<Player> playerList = new();
            string queryString = "SELECT Id, Name, Nationality, Position, DateOfBirth, Height, Weight, PreferedFoot FROM Player;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            playerList.Add(new Player()
                            {
                                Id = (int)reader[0],
                                Name = reader[1].ToString(),
                                Nationality = reader[2].ToString(),
                                Position = (Position)Enum.Parse(typeof(Position), reader[3].ToString()),
                                DateOfBirth = (DateTime)reader[4],
                                Height = (int)reader[5],
                                Weight = (int)reader[6],
                                PreferedFoot = (Foot)Enum.Parse(typeof(Foot), reader[7].ToString())
                            });
                        }
                    }
                } //(Foot)Enum.Parse(typeof(Foot), reader[3].ToString(), true);
                catch (Exception e)
                {
                    Console.WriteLine($"Ups. Error:{e.GetType} {e.Message}");
                }
            }
            return playerList;
        }

        internal int UpdateTeamData(Team team)
        {
            string queryString = $"UPDATE Team SET TeamName = @teamName WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = team.Id;
                command.Parameters.Add("@teamName", SqlDbType.NVarChar).Value = team.Name;
                command.Connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
    }
}
