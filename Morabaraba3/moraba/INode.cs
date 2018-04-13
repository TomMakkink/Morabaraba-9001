using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface INode
    {
        void addCow(Cow cow);

        void removeCow();

        List<string> getNeighbours();
        
        string Position { get; }

        bool occupied { set; }

        List<string> neighbours { get; }

        Cow Cow { get; }

    }
}
