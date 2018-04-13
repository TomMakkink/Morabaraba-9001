using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Cow : ICow
    {
        public string Position { get; set; }

        public Team Team { get; private set; }

        public bool isShootable(IEnumerable<Node> nodeBoard)
        {
            throw new NotImplementedException();
        }
       

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
    }
}
