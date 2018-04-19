using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Node : INode
    {
        public  string Position { get; private set; }

        public bool occupied { get; private set; }

        public List<string> neighbours { get; private set; }

        public Cow Cow { get; set; }

        public Node(string pos, List<string> friends)// friends are the neighbouring nodes
        {
            Position = pos;
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

        public string getPosition()
        {
            return Position;
        }

        public bool getOccupied ()
        {
            return occupied;
        }

     
    }
}
