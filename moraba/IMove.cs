using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
   public  interface IMove
    {
        bool Placing(string placeNode);



        void moveCow(INode startNode, INode endNode);

        

    }
}
