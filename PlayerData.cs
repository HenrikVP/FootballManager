using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    internal class PlayerData
    {
        internal Player P1 = new() {
            Name ="Lionel Messi", 
            Nationality = "Argentina",
            DateOfBirth = new DateTime(1987, 6, 24), 
            Height = 169, 
            Weight = 67, 
            PreferedFoot = Foot.Left,
            Position = Position.RW
        };
        internal Player P2 = new()
        {
            Name = "Christiano Ronaldo",
            Nationality = "Portugal",
            DateOfBirth = new DateTime(1985, 2, 5),
            Height = 169,
            Weight = 67,
            PreferedFoot = Foot.Left,
            Position = Position.RW
        };



    }
}
