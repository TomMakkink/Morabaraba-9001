using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface inputValidation
    {
        Node checkNodeExists(string str);

        bool checkNodeIsOccupied(Node node);

        bool isNeighbour(Node startNode, Node endNode);
    }
}
