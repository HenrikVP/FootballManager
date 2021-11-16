using FootballManager;

Console.WriteLine("Hello, Football World!");

//new Sql().ReadTeamData();

//TeamData teamData = new();
//List<Team> teams = new List<Team>();


List<Team> teamlist = new Sql().ReadTeamData();
Console.WriteLine("Pick a team");
foreach (Team team in teamlist)
{
    Console.WriteLine(team.Id + " " + team.Teamname);
}

Console.WriteLine("Players: ");
List<Player> playerlist = new Sql().ReadPlayerData();
foreach (Player p in playerlist)
{
    Console.WriteLine($"{p.Id}, {p.Name}, {p.Position}, {p.Nationality}, {p.PreferedFoot}, " +
        $"{p.Weight}, {p.Height}, {p.DateOfBirth}");
}

