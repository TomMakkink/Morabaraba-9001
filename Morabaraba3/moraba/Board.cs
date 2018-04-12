using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    class Board : IBoard, IMove
    {
        public void Flying(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INode> mainNode(string Position)
        {
            throw new NotImplementedException();
        }

        public void Moving(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }

        public void Placeing(string placeNode)
        {
            throw new NotImplementedException();
        }

        public bool validateMove(string str)
        {
            throw new NotImplementedException();
        }
    }
}
