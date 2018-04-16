using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
     interface IBoard
    {
        List<Node> getMainNodeList ();
        void printBoard();
        Node getNodeFromString(string node);
       
    }
}
