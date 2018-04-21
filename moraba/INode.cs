using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
   public  interface INode
    {
        void addCow(ICow cow);

        void removeCow();

        List<string> getNeighbours();
        
        string Position { get; }

        bool occupied { get; }

        List<string> neighbours { get; }

        ICow Cow { get; }

        string getPosition();

        bool getOccupied();

        void changeOccupied(bool cha);
    }
}
