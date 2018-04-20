using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface inputValidation
    {
        bool checkNodeExists(string str);

        bool checkNodeIsOccupied(INode node);

        bool isNeighbour(INode startNode, INode endNode);

        bool validateMove(INode startNode, INode endNode);

        bool validateFlying(string position);
    }
}
