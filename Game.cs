namespace FootballManager
{
    internal class Game
    {
        enum Zone {Left, Center, Right }

        Team t1, t2;
        Random rnd = new();
        public Game(Team a, Team b)
        {
            t1 = a;
            t2 = b;
            Console.WriteLine("This sunday afternoon " +
                "we will see the match between " +
                $"{t1.Name} and {t2.Name}.");
            Lineup(t1);
            Lineup(t2);

            Playmaking();
        }

        void Lineup(Team team)
        {
            Console.WriteLine(team.Name);
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"\t{team.Players[i].Name} {team.Players[i].Position}");
            }
        }

        void Playmaking()
        {
            int TotalMidfieldSkillT1 =
                GetRandomSkill(t1.Players[6]) +
                GetRandomSkill(t1.Players[8]) +
                (GetRandomSkill(t1.Players[7]) +
                GetRandomSkill(t1.Players[11])) / 2;
            int TotalMidfieldSkillT2 =
                GetRandomSkill(t2.Players[6]) +
                GetRandomSkill(t2.Players[8]) +
                (GetRandomSkill(t2.Players[7]) +
                GetRandomSkill(t2.Players[11])) / 2;

            int zone = rnd.Next(0, 3);
            if (TotalMidfieldSkillT1 > TotalMidfieldSkillT2)
            {
                //T1 gets the attack
                Console.WriteLine($"{t1.Name} builds up an attack in the {zone} zone");
                Attack(t1, t2, zone);
            }
            else
            {
                //T2 gets the attack
                Console.WriteLine($"{t2.Name} builds up an attack in the {zone} zone");
                Attack(t2, t1, rnd.Next(0, 3));
            }
        }

        void Attack(Team attack, Team defend, int zone)
        {
            Console.WriteLine($"The attack is in the {(Zone)zone} zone");
            //First is central, otherwise (1,3) is side attacks
            int[] plist = new int[] { 10, 9, 4, 5 };
            if (zone == 0) plist = new int[] { 10, 11, 2, 4 };
            if (zone == 2) plist = new int[] { 9, 7, 3, 5 };

            //Do attack
            int TotalAttackSkill =
                GetRandomSkill(attack.Players[plist[0]]) +
                GetRandomSkill(attack.Players[plist[1]]);
            int TotalDefenseSkill =
                GetRandomSkill(defend.Players[plist[2]]) +
                GetRandomSkill(defend.Players[plist[3]]);
            if (TotalAttackSkill > TotalDefenseSkill)
            {
                //Her har angrebet vundet zonen
                Console.WriteLine($"{attack.Players[plist[0]].Name} and {attack.Players[plist[1]].Name} wins the attack!");
            }
            else
            {
                Console.WriteLine($"{defend.Players[plist[2]].Name} and {defend.Players[plist[3]].Name} defends off the attack!");
                //Her vinder forsvaret zonen
                Playmaking();
            }

        }

        //Midtbanen bliver udregnet (skills)
        //alle spillere har default 50
        //Random 1-MaxSkill
        //CM = 1-50, CM = 1-50, RM = 1-50/2, LM = 1-50/2
        //Hvem har højest værdi vinder kampen om zonen.

        int GetRandomSkill(Player player)
        {
            return rnd.Next(1, player.Skill);
        }

    }
}
