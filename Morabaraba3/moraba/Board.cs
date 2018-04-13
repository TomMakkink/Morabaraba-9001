using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
      public class Board : IBoard, IMove
    {
        private List<Node> mainNodeList = new List<Node> { };

        public void Flying(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }


        public Board()
        {
            mainNodeList.Add(new Node("a0", new List<string> { "a3", "d0", "b1" }));
            mainNodeList.Add(new Node("a3", new List<string> { "a0", "b3", "a6" }));
            mainNodeList.Add(new Node("a6", new List<string> { "a3", "d6", "b5" }));
            mainNodeList.Add(new Node("b1", new List<string> { "a0", "c2", "d1", "b3" }));
            mainNodeList.Add(new Node("b3", new List<string> { "a3", "c3", "b1", "b5" }));
            mainNodeList.Add(new Node("b5", new List<string> { "a6", "c4", "b3", "d5" }));
            mainNodeList.Add(new Node("c2", new List<string> { "b1", "c3", "d2" }));
            mainNodeList.Add(new Node("c3", new List<string> { "c2", "c4", "b3" }));
            mainNodeList.Add(new Node("c4", new List<string> { "c3", "b5", "d4" }));
            mainNodeList.Add(new Node("d0", new List<string> { "d1", "a0", "g0" }));
            mainNodeList.Add(new Node("d1", new List<string> { "d0", "b1", "d2", "f1" }));
            mainNodeList.Add(new Node("d2", new List<string> { "d1", "c2", "e2" }));
            mainNodeList.Add(new Node("d4", new List<string> { "d5", "c4", "e4" }));
            mainNodeList.Add(new Node("d5", new List<string> { "d4", "d6", "b5", "f5" }));
            mainNodeList.Add(new Node("d6", new List<string> { "d5", "a6", "g6" }));
            mainNodeList.Add(new Node("e2", new List<string> { "f1", "e3", "d2" }));
            mainNodeList.Add(new Node("e3", new List<string> { "e2", "e4", "f3" }));
            mainNodeList.Add(new Node("e4", new List<string> { "e3", "f5", "d4" }));
            mainNodeList.Add(new Node("f1", new List<string> { "d1", "f3", "e2", "g0" }));
            mainNodeList.Add(new Node("f3", new List<string> { "f1", "e3", "g3", "f5" }));
            mainNodeList.Add(new Node("f5", new List<string> { "g6", "d5", "e4" }));
            mainNodeList.Add(new Node("g0", new List<string> { "g3", "f1", "d0" }));
            mainNodeList.Add(new Node("g3", new List<string> { "g0", "g6", "f3" }));
            mainNodeList.Add(new Node("g6", new List<string> { "g3", "f5", "d6" }));

        }
      

        public List<Node> getMainNodeList ()
        {
            return mainNodeList;
        }

        public void Moving(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }

        public void Placing(string placeNode)
        {
            throw new NotImplementedException();
        }

        public bool validateMove(string str)
        {
            throw new NotImplementedException();
        }
    }
}
