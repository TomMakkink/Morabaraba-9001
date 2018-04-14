using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface inputValidation
    {
        bool checkNodeExists(string str);

        bool checkNodeIsOccupied(Node node);

        bool isNeighbour(Node startNode, Node endNode);

        bool validateMove(Node startNode, Node endNode, Player player);
    }
}
