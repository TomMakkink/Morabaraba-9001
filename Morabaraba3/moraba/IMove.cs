using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
        void Placing(string placeNode);
        void Moving(string startNode, string endNode);
        void Flying(string startNode, string endNode);

        bool validatePlacing(string str);

        bool validateMoving(string startNode,string endNode);
    }
}
