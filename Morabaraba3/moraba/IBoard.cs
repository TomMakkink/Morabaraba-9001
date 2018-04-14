using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
     interface IBoard
    {
        List<Node> getMainNodeList ();

        Node getNodeFromString(string node);
       
    }
}
