using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Node : INode
    {
        public string Position { get; set; }

        public bool occupied { get;  set; }

        public List<string> neighbours { get; set; }

        public Cow Cow { get; set; }

        public Node(string pos, List<string> friends)
        {
            Position = pos;
            occupied = false;
            neighbours = friends;
            Cow = null;
        }

  
        public void addCow(string pos, Player player)
        {
            Cow = new Cow(pos, player.Team);
            occupied = true;
            Position = pos;
        }

        public List<string> getNeighbours()
        {
            return neighbours;
        }

        public void removeCow()
        {
            Cow = null;
            occupied = false;
        }
    }
}
