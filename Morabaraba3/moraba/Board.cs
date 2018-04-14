using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace moraba
{
      public class Board : IBoard, IMove, inputValidation
    {
        public List<Node> mainNodeList = new List<Node> { };

        public bool Flying(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }

       public int numOfCowsOntheField()
        {
            int total = 0;
            foreach(Node x in mainNodeList)
            {
                if (x.occupied)
                    total++;
            }
            return total;
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

        public bool Moving(string position,Player player)
        {
            // Input validation 
            if (position.Length == 5 && player.numCowsToPlace() == 0)
            {
                string start = getStartNode(position);
                string end = getEndNode(position);
                if (checkNodeExists(start) && checkNodeExists(end))
                {
                    Node tempStart = getNodeFromString(start);
                    Node tempEnd = getNodeFromString(end);
                    if (validateMove(tempStart, tempEnd, player))
                    {
                        //moveCow(tempStart, tempEnd);
                    }
                }
            }
            return false; 
        }

        public bool validateMove(Node startNode, Node endNode, Player player)
        {
            if (checkNodeIsOccupied(startNode) == true && checkNodeIsOccupied(endNode) == false)
            {
                if (startNode.Cow.Team == player.Team)
                {
                    if (isNeighbour(startNode, endNode))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Placing(string placeNode, Player player)
        {
            if (checkNodeExists(placeNode))
            {
                Node temp = getNodeFromString(placeNode);
                if (!checkNodeIsOccupied(temp))
                {
                    int index = mainNodeList.FindIndex(x => x.Position == placeNode);
                    mainNodeList[index].addCow(player.CowsForPlacing[0]);
                    player.placedCow();
                    return true;
                }
            }
            return false;
        }

        public string getStartNode(string input)
        {
            input.ToLower();
            return input.Split(' ')[0];
        }

        public string getEndNode(string input)
        {
            input.ToLower();
            return input.Split(' ')[1];
        }

        public bool checkNodeExists(string str)
        {
            foreach (Node n in mainNodeList)
            {
                if (n.Position == str) return true;
            }
            return false;
        }

        public bool isNeighbour(Node startNode, Node endNode)
        {
            return startNode.neighbours.Contains(endNode.Position);
        }

        public bool checkNodeIsOccupied(Node node)
        {
            if (node == null) return false;
            return node.occupied;
        }

        public Node getNodeFromString(string str)
        {
            foreach (Node n in mainNodeList)
            {
                if (n.Position == str) return n;
            }
            return null;
        }
    }
}
