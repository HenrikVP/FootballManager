namespace FootballManager
{
    internal class Setup
    {
        Sql sql = new();
        public Setup()
        {
            Console.WriteLine("Hello, Football World!");         
            //Add teams from DB and players to the teams
            List<Team> teamlist = Initialize();
            //Starts a game
            Game game = new(teamlist[0], teamlist[1]);
        }
        private List<Team> Initialize()
        {
            List<Team> teamlist = sql.ReadTeamData();
            //AddFootballNames(teamlist);
            
            List<Player> playerlist = sql.ReadPlayerData();
            int i = 0;
            foreach (var player in playerlist)
            {
                player.Skill = new Random().Next(20, 100);
                teamlist[i / 20].Players.Add(player);
                i++;
            }
            //ShowTeams(teamlist);
            //ShowPlayers(playerlist);
            return teamlist;
        }

        private void ShowTeams(List<Team> teamlist)
        {
            Console.WriteLine("\nTeamlist: ");
            foreach (Team team in teamlist)
            {
                Console.WriteLine(team.Id + " " + team.Name);
                foreach (var p in team.Players)
                {
                    Console.WriteLine($"\t{p.Id} {p.Name} {p.Skill} {p.Position}");
                }
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
