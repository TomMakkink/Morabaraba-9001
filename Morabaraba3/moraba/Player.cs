using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer
    {
        public string Name { get; set; }


        public Team Team { get; set; }

        // default constructor

        // constructor
        public Player(string name, Team team)
        {
            Name = name;
            Team = team;
        }

       

        public bool canShoot(IEnumerable<Node> b)
        {
            throw new NotImplementedException();
        }

    }
}
