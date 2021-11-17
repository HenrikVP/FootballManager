namespace FootballManager
{
    public enum Position { GK, CB, RB, LB, CM, RM, LM, ST, RW, LW }
    public enum Foot { Left, Right }

    public class Player : Superbase
    {
        public string Nationality { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Foot PreferedFoot { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Skill { get; set; }
    }
}