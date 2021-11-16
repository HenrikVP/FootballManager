namespace FootballManager
{
    public enum Position { GK, CB, RB, LB, CM, RM, LM, ST, RW, LW }
    public enum Foot { Left, Right }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Foot PreferedFoot { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}