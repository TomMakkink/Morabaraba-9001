using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace moraba
{
      public class Board : IBoard, IMove, inputValidation
    {
        public List<Node> mainNodeList = new List<Node> { };

        public bool Flying(string position, Player player)
        {
            if (validateFlying(position, player))
            {
                string start = getStartNode(position);
                string end = getEndNode(position);

                Node startNode = getNodeFromString(start);
                Node endNode = getNodeFromString(end);
                moveCow(startNode, endNode, player);
                return true;
            }
            return false;
        }



        public void printBoard()
        {
            Console.WriteLine("    a   b cde  f   g :-)");
            for (int i = 0; i < mainNodeList.Count; i++)
            {
                switch (i)
                {
                    case 0://first row
                        if (mainNodeList[i].occupied)
                        {
                            Console.Write(String.Format("1   {0}------", mainNodeList[i].Cow.Team));
                        }
                        else
                        {
                            Console.Write("1   ‡------");
                        }
                        break;
                    case 1://first row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}------", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡------");
                        break;
                    case 2:// first row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡");
                        Console.WriteLine(@"    | \    |    / |");
                        break;
                    case 3:// second row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("2   |  {0}---", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("2   |  ‡---");
                        break;
                    case 4:// 2nd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}---", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡---");
                        break;
                    case 5:// 2nd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}  |", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡  |");
                        Console.WriteLine(@"    |  |\  |  /|  |");
                        break;
                    case 6:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("3   |  |   {0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("3   |  | ‡-");
                        break;
                    case 7:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡-");
                        break;
                    case 8:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0} |  |", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡ |  |");
                        Console.WriteLine(@"    |  | |   | |  |");
                        break;
                    case 9:// 4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("4   {0}--", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("4   ‡--");
                        break;
                    case 10:// 4ht row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡-");
                        break;
                    case 11://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}   ", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡   ");
                        break;
                    case 12://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡-");
                        break;
                    case 13://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}--", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡--");
                        break;
                    case 14://4th row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡");
                        Console.WriteLine(@"    |  | |   | |  |");
                        break;
                    case 15:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("3   |  |   {0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("5   |  | ‡-");
                        break;
                    case 16:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡-");
                        break;
                    case 17:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0} |  |", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡ |  |");
                        Console.WriteLine(@"    |  |/  |  \|  | ");
                        break;
                    case 18://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("6   |  {0}---", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("6   |  ‡---");
                        break;
                    case 19://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}---", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡---");
                        break;
                    case 20://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}  |", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡  |");
                        Console.WriteLine(@"    | /    |    \ |");
                        break;
                    case 21:
                        if (mainNodeList[i].occupied)
                        {
                            Console.Write(String.Format("7   {0}------", mainNodeList[i].Cow.Team));
                        }
                        else
                        {
                            Console.Write("7   ‡------");
                        }
                        break;
                    case 22:
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}------", mainNodeList[i].Cow.Team));
                        else
                            Console.Write("‡------");
                        break;
                    case 23:
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", mainNodeList[i].Cow.Team));
                        else
                            Console.WriteLine("‡");
                        break;
                }
            }
        }



        public int numOfCowsOntheField()
        {
            int total = 0;
            foreach (Node x in mainNodeList)
            {
                if (x.occupied)
                    total++;
            }
            return total;
        }
        public int numOfCowsOntheField(Team team)
        {
            int total = 0;
            foreach (Node x in mainNodeList)
            {
                if (x.occupied && (x.Cow.Team == team))
                    total++;
            }
            return total;
        }
        public bool validateFlying(string position, Player player)
        {
            if (position.Length == 5 && position.Contains(" ") && player.CowsAlive.Count == 3)
            {
                string start = getStartNode(position);
                string end = getEndNode(position);
                if (checkNodeExists(start) && checkNodeExists(end))
                {
                    Node startNode = getNodeFromString(start);
                    Node endNode = getNodeFromString(end);
                    if (checkNodeIsOccupied(startNode) == true && checkNodeIsOccupied(endNode) == false)
                    {
                        if (startNode.Cow.Team == player.Team)
                        {
                                return true;
                        }
                    }
                }
            }
            return false;
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
            if (position.Length == 5 && position.Contains(" ") && player.numCowsToPlace() == 0)
            {
                string start = getStartNode(position);
                string end = getEndNode(position);
                if (checkNodeExists(start) && checkNodeExists(end))
                {
                    Node tempStart = getNodeFromString(start);
                    Node tempEnd = getNodeFromString(end);
                    if (validateMove(tempStart, tempEnd, player))
                    {
                        moveCow(tempStart, tempEnd, player);
                        return true;
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
        public void moveCow(Node startNode, Node endNode, Player player)
        {
            int startIndex = mainNodeList.FindIndex(x => x.Position == startNode.Position);
            int endIndex = mainNodeList.FindIndex(x => x.Position == startNode.Position);

            mainNodeList[endIndex].addCow(endNode.Cow);
            mainNodeList[startIndex].removeCow();
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
