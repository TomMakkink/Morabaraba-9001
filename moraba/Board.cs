using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace moraba
{
      public class Board : IBoard
    {
        private List<INode> mainNodeList = new List<INode> { };

        public INode getNodeFromString(string str)
        {
            foreach (INode n in mainNodeList)
            {
                if (n.Position.Equals(str)) return n;
            }
            return null;
        }


        public void RemoveCow(int index , IPlayer player)
        {
            mainNodeList[index].removeCow(); // this will remove the cow from the board 
            player.killCow(mainNodeList[index].Position); // this removes the cow from cowsAlive List 
        }

        public void printBoard()
        {
            Console.WriteLine("    0  1 2     3     4 5  6 :-)");
            for (int i = 0; i < mainNodeList.Count; i++)
            {
                string token = "[]";
                if (mainNodeList[i].occupied)
                {
                    if(mainNodeList[i].Cow.Team == Team.DarkCow)
                    {
                        token = "DC";
                    }
                    if(mainNodeList[i].Cow.Team == Team.LightCow)
                    {
                        token = "LC";
                    }
                }

                switch (i)
                {
                    case 0://first row
                        if (mainNodeList[i].occupied)
                        {
                            Console.Write(String.Format("a   {0}---------", token));
                        }
                        else
                        {
                            Console.Write("a   ‡‡---------");
                        }
                        break;
                    case 1://first row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}---------", token));
                        else
                            Console.Write("‡‡---------");
                        break;
                    case 2:// first row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", token));
                        else
                            Console.WriteLine("‡‡");
                        Console.WriteLine(@"    | \        |         / |");
                        break;
                    case 3:// second row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("b   |  {0}------", token));
                        else
                            Console.Write("b   |  ‡‡------");
                        break;
                    case 4:// 2nd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}------", token));
                        else
                            Console.Write("‡‡------");
                        break;
                    case 5:// 2nd row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}  |", token));
                        else
                            Console.WriteLine("‡‡  |");
                        Console.WriteLine(@"    |  |\      |       /|  |");
                        break;
                    case 6:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("c   |  |   {0}----", token));
                        else
                            Console.Write("c   |  | ‡‡----");
                        break;
                    case 7:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}----", token));
                        else
                            Console.Write("‡‡----");
                        break;
                    case 8:// 3rd row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0} |  |", token));
                        else
                            Console.WriteLine("‡‡ |  |");
                        Console.WriteLine(@"    |  |  |          |  |  |");
                        break;
                    case 9:// 4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("d   {0}-", token));
                        else
                            Console.Write("d   ‡‡-");
                        break;
                    case 10:// 4ht row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", token));
                        else
                            Console.Write("‡‡-");
                        break;
                    case 11://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format(@"{0}         ", token));
                        else
                            Console.Write(@"‡‡         ");
                        break;
                    case 12://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", token));
                        else
                            Console.Write("‡‡-");
                        break;
                    case 13://4th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}-", token));
                        else
                            Console.Write("‡‡-");
                        break;
                    case 14://4th row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", token));
                        else
                            Console.WriteLine("‡‡");
                        Console.WriteLine(@"    |  |  |          |  |  |");
                        break;
                    case 15:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("e   |  |   {0}----", token));
                        else
                            Console.Write("e   |  | ‡‡----");
                        break;
                    case 16:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}----", token));
                        else
                            Console.Write("‡‡----");
                        break;
                    case 17:// 5th row
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0} |  |", token));
                        else
                            Console.WriteLine("‡‡ |  |");
                        Console.WriteLine(@"    |  |/      |       \|  | ");
                        break;
                    case 18://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("f   |  {0}------", token));
                        else
                            Console.Write("f   |  ‡‡------");
                        break;
                    case 19://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}------", token));
                        else
                            Console.Write("‡‡------");
                        break;
                    case 20://6th row
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}  |", token));
                        else
                            Console.WriteLine("‡‡  |");
                        Console.WriteLine(@"    | /        |         \ |");
                        break;
                    case 21:
                        if (mainNodeList[i].occupied)
                        {
                            Console.Write(String.Format("g   {0}---------", token));
                        }
                        else
                        {
                            Console.Write("g   ‡‡---------");
                        }
                        break;
                    case 22:
                        if (mainNodeList[i].occupied)
                            Console.Write(String.Format("{0}---------", token));
                        else
                            Console.Write("‡‡---------");
                        break;
                    case 23:
                        if (mainNodeList[i].occupied)
                            Console.WriteLine(String.Format("{0}", token));
                        else
                            Console.WriteLine("‡‡");
                        break;
                }
            }
        }

        public bool checkNodeExists(string str)
        {
            foreach (INode n in mainNodeList)
            {
                if (n.Position == str) return true;
            }
            return false;
        }

        public bool isNeighbour(INode startNode, INode endNode)
        {
            return startNode.neighbours.Contains(endNode.Position);
        }

        public bool checkNodeIsOccupied(INode node)
        {
            if (node == null) return false;
            return node.getOccupied();
        }

        public int numOfCowsOntheField()
        {
            int total = 0;
            foreach (INode x in mainNodeList)
            {
                if (x.occupied)
                    total++;
            }
            return total;
        }
        public int numOfCowsOntheField(Team team)
        {
            if (team == Team.DarkCow || team == Team.LightCow)
            {
                int total = 0;
                foreach (INode x in mainNodeList)
                {
                    if (x.occupied && (x.Cow.Team == team))
                        total++;
                }
                return total;
            }
            return 1000;// returns 1000 if something goes wrong
            
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
      

        public List<INode> getMainNodeList ()
        {
            return mainNodeList;
        }

        bool IBoard.checkNodeIsOccupied(int index)
        {
            if (getMainNodeList()[index].occupied == false) return false;
            return true;
        }
    }
}
