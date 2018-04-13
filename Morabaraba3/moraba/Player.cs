using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public List<Cow> CowsLeft = new List<Cow> { };
        public Team Team { get; set; }

        // default constructor

        // constructor
        public Player(string name, Team team)
        {
            Name = name;
            Team = team;
            makeCows(team);
        }

        private void makeCows(Team team)
        {
            for (int i = 0; i < 13; i++)
                CowsLeft.Add(new Cow(team));
        }    
        
        public int numCowsLeft ()
        {
            return CowsLeft.Count;
        }
       

        public bool canShoot(IEnumerable<Node> b)
        {
            throw new NotImplementedException();
        }

    }
}
