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
        public Cow cow;

      

        public Node(string pos, List<string> friends)
        {
            position = pos;
            occupied = false;
            neighbours = friends;
            cow = null;
        }
        public void addCow(Cow cow)
        {
            throw new NotImplementedException();
        }

        public void getNeighbours()
        {
            throw new NotImplementedException();
        }

        public void removeCow()
        {
            throw new NotImplementedException();
        }
    }
}
