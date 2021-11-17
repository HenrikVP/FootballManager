using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    internal class Game
    {
        Team t1, t2;

        public Game(Team a, Team b)
        {
            t1 = a;
            t2 = b;
            Console.WriteLine("This sunday afternoon " +
                "we will see the match between " +
                $"{t1.Name} and {t2.Name}.");
        }

        void Playmaking()
        {
            var TotalMidfieldSkillT1 = 
                t1


        }
        //Midtbanen bliver udregnet (skills)
        //alle spillere har default 50
        //Random 1-MaxSkill
        //CM = 1-50, CM = 1-50, RM = 1-50/2, LM = 1-50/2
        //Hvem har højest værdi vinder kampen om zonen.




    }
}
