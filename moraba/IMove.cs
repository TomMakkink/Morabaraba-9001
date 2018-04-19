using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
        bool Placing(string placeNode);
       

        void moveCow(Node startNode, Node endNode);

        

    }
}
