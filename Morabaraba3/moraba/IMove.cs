using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
        bool Placing(string placeNode, Player player);
        bool Moving(string position, Player player);

        void moveCow(string startNode, string endNode, Player player);
        bool Flying(string startNode, string endNode);


        string getStartNode(string input);

        string getEndNode(string input);
    }
}
