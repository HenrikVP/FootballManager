using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    internal class TeamData
    {
        PlayerData pData = new PlayerData();

        public TeamData()
        {
            AddData();
        }
        private void AddData()
        {
            Team t1 = new() { 
                Name = "Manchester United",
                Players = new List<Player>() { pData.P1, pData.P2 }
            };

        }



    }
}
