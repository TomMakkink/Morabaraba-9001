using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Node : INode
    {
        public string position;
        public bool occupied;
        public List<string> neighbours;
        public Cow Cow;

      
        public Node(string pos, List<string> friends)
        {
            position = pos;
            occupied = false;
            neighbours = friends;
            Cow = null;
        }
        public void addCow(Cow cow)
        {
            Cow = cow;
            occupied = true;
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
