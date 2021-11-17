namespace FootballManager
{
    internal class Setup
    {
        Sql sql;
        public Setup()
        {
            Console.WriteLine("Hello, Football World!");
            sql = new();
            Start();
        }
        private void Start()
        {
            List<Team> teamlist = sql.ReadTeamData();
            //ShowTeams(teamlist);
            //AddFootballNames(teamlist);
            ShowTeams(teamlist);

            List<Player> playerlist = sql.ReadPlayerData();
            //ShowPlayers(playerlist);
        }

        private void ShowTeams(List<Team> teamlist)
        {
            Console.WriteLine("\nTeamlist: ");
            foreach (Team team in teamlist)
            {
                Console.WriteLine(team.Id + " " + team.Name);
            }
        }

        private void AddFootballNames(List<Team> teamlist)
        {
            int counter = 0;
            foreach (Team team in teamlist)
            {
                Random rand = new Random();
                switch (rand.Next(5))
                {
                    case 0:
                        team.Name += " United";
                        break;
                    case 1:
                        team.Name = "FC " + team.Name;
                        break;
                    case 2:
                        team.Name = "Sporting " + team.Name;
                        break;
                    case 3:
                        team.Name += " City";
                        break;
                    case 4:
                        team.Name += " F.C.";
                        break;
                    default:
                        break;
                }
                int i = sql.UpdateTeamData(team);
                counter += i;
            }
            Console.WriteLine("Rows Affected in total: " + counter);
        }

        private void ShowPlayers(List<Player> playerlist)
        {
            Console.WriteLine("\nPlayerlist: ");
            foreach (Player p in playerlist)
            {
                Console.WriteLine($"{p.Id}, {p.Name}, {p.Position}, {p.Nationality}, {p.PreferedFoot}, " +
                    $"{p.Weight}, {p.Height}, {p.DateOfBirth}");
            }
        }

        private List<Player> SubPlayerList(List<Player> playerlist)
        {
            var subset = from player in playerlist
                         where player.Id > 100 && player.Id < 120
                         orderby player.Name
                         select player;
            return subset.ToList();
        }
    }
}
