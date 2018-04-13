using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
<<<<<<< HEAD
        void Placing(string placeNode);
=======
        void Placing(string placeNode, Player player);
>>>>>>> Test
        void Moving(string startNode, string endNode);
        void Flying(string startNode, string endNode);

        string getStartNode(string input);

        string getEndNode(string input);
    }
}
