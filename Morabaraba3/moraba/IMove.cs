using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
        void Placing(string placeNode, Player player);
        void Moving(string startNode, string endNode, Player player);
        void Flying(string startNode, string endNode);

        string getStartNode(string input);

        string getEndNode(string input);
    }
}
