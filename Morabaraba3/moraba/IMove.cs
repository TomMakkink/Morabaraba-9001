using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IMove
    {
        void Placeing(string placeNode);
        void Moving(string startNode, string endNode);
        void Flying(string startNode, string endNode);

        bool validateMove(string str);
    }
}
