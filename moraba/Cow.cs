using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Cow : ICow
    {
        private string Position { get; set; }

        public Team Team { get; set; }
        
        public Cow(Team team)
        {
            Position = "a0";
            Team = team;
        }

        public Cow(string pos, Team team)
        {
            Position = pos;
            Team = team;
        }

        public string getPosition()
        {
            return Position;
        }
        
        public void changePosition(string x)
        {
            Position = x;
        }
        
    }
}
