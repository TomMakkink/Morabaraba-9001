using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Umpire : IUmpire
    {
        private int turns;
        private IPlayer currentPlayer;
        private IPlayer enemy;
   //     private IBoard board;
        private bool justGotMill = false;

        public IPlayer getCurrentPlayer()
        {
            return currentPlayer;
        }

        public int getTurns()
        {
            return turns;
        }
        public void changeTurns(int x)
        {
            turns += x;
        }
        public IPlayer getEnemy()
        {
            return enemy;
        }

        public Umpire(IPlayer player1, IPlayer player2)
        {
            turns = 1;
            currentPlayer = player1;
            enemy = player2;
        }

        public void changePlayers()
        {
            IPlayer temp = currentPlayer;
            currentPlayer = enemy;
            enemy = temp;
            justGotMill = false;
        }
        private List<List<string>> getMillOptions(int index)
        {
            string caseSwitch = currentPlayer.getBoard().getMainNodeList()[index].Position;

            switch (caseSwitch)
            {
                case "a0":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a0", "d0", "g0" }, new List<string> { "a0", "b1", "c2" } };
                case "a3":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a3", "b3", "c3" } };
                case "a6":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a6", "g6", "d6" }, new List<string> { "a6", "b5", "c4" } };
                case "b1":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "a0", "b1", "c2" }, new List<string> { "b1", "d1", "f1" } };
                case "b3":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "a3", "b3", "c3" } };
                case "b5":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "b5", "a6", "c4" }, new List<string> { "b5", "f5", "d5" } };
                case "c2":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "c2", "d2", "e2" }, new List<string> { "a0", "b1", "c2" } };
                case "c3":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "a3", "b3", "c3" } };
                case "c4":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "c4", "d4", "e4" }, new List<string> { "c4", "b5", "a6" } };
                case "d0":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "a0", "d0", "g0" } };
                case "d1":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "b1", "d1", "f1" } };
                case "d2":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "d2", "e2", "c2" } };
                case "d4":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "d4", "c4", "e4" } };
                case "d5":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "d5", "b5", "f5" } };
                case "d6":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "a6", "d6", "g6" } };
                case "e2":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e2", "f1", "g0" }, new List<string> { "e2", "d2", "c2" } };
                case "e3":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e3", "f3", "g3" } };
                case "e4":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e4", "f5", "g6" }, new List<string> { "e4", "d4", "c4" } };
                case "f1":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "f1", "e2", "g0" }, new List<string> { "f1", "d1", "b1" } };
                case "f3":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "g3", "e3", "f3" } };
                case "f5":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "f5", "e4", "g6" }, new List<string> { "f5", "d5", "b5" } };
                case "g0":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g0", "f1", "e2" }, new List<string> { "g0", "a0", "d0" } };
                case "g3":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g3", "f3", "e3" } };
                case "g6":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g6", "d6", "a6" }, new List<string> { "g6", "f5", "e4" } };


            }
            return new List<List<string>> { };
        }

        public void play()
        {
            while (win())
            {
                if (turns <= 24)//placing stage
                {
                    if(turns != 1)
                    {
                        if (turns % 2 == 1)
                        {
                            changePlayers();
                        }
                        else
                        {
                            changePlayers();
                        }
                    }
                  
                    if (currentPlayer.numCowsToPlace() != 0)
                    {
                        string playerPlace = askToPlace();
                        while (!validatePlacing(playerPlace))
                        {
                            Console.WriteLine("that move wasnt the best maybe try again?");
                            playerPlace = askToPlace();
                        }
                        currentPlayer.Placing(playerPlace);
                        //currentPlayer.getBoard().printBoard();
                        mill(currentPlayer.getLastNode());
                        currentPlayer.getBoard().printBoard();
                    }
                    else
                    {
                        if (currentPlayer.numCowsAlive() != 3)
                        {
                            string playerPlace = askToMove();
                            while (!validateMove(playerPlace))
                            {
                                Console.WriteLine("that move wasnt the best maybe try again?");
                                playerPlace = askToMove();
                            }
                            string start = getStartNode(playerPlace);
                            string end = getEndNode(playerPlace);
                            INode startNode = currentPlayer.getBoard().getNodeFromString(start);
                            INode endNode = currentPlayer.getBoard().getNodeFromString(end);
                            currentPlayer.moveCow(startNode, endNode);
                            currentPlayer.getBoard().printBoard();
                            currentPlayer.GetRidOfMill(start);
                            mill(currentPlayer.getLastNode());
                            currentPlayer.getBoard().printBoard();
                        }
                        else
                        {
                            string playerPlace = askToFly();
                            while (!validateFlying(playerPlace))
                            {
                                Console.WriteLine("that move wasnt the best maybe try again?");
                                playerPlace = askToPlace();
                            }
                            string start = getStartNode(playerPlace);
                            string end = getEndNode(playerPlace);
                            INode startNode = currentPlayer.getBoard().getNodeFromString(start);
                            INode endNode = currentPlayer.getBoard().getNodeFromString(end);
                            currentPlayer.moveCow(startNode, endNode);
                            currentPlayer.GetRidOfMill(start);
                            currentPlayer.getBoard().printBoard();
                            mill(currentPlayer.getBoard().getNodeFromString(playerPlace));
                            currentPlayer.getBoard().printBoard();
                        }
                    }
                }
                turns++;
            }
    
        }

        public bool win()
        {
            if (enemy.numCowsAlive() < 3)
            {
                printWinner();
                return false;//false then current wins
            }

            List<INode> playerNodeList = getPlayerNodeList(enemy.getBoard().getMainNodeList());
            if (turns > 24)
            {
                for (int i = 0; i < playerNodeList.Count; i++)
                {
                    List<string> neighours = playerNodeList[i].neighbours;
                    for (int j = 0; j < neighours.Count; j++)
                    {
                        INode currentNode = enemy.getBoard().getNodeFromString(neighours[j]);
                        if (!currentNode.occupied)
                        {
                            return true;// true means theres a free node to move to
                        }
                    }

                }
                return false;// no free nodes to move to
            }

            return true; 
        }

        private List<INode> getPlayerNodeList(List<INode> mainNodeList)
        {
            List<INode> playersNode = new List<INode>();
            for (int i = 0; i < mainNodeList.Count; i++)
            {
                if (mainNodeList[i].occupied)
                {
                    if(mainNodeList[i].Cow.Team == enemy.Team)
                    {
                        playersNode.Add(mainNodeList[i]);
                    }
                }
            }
            return playersNode;
        }

        void printWinner()
        {
            Console.WriteLine(String.Format("Good job. {0} have savagely murdered the other teams cow. You may now proclaim victory and dance around their corpses.", currentPlayer.Name));
            //Console.Read();
        }

         #region askingToMove
        public string askToFly()
        {
            Console.WriteLine(string.Format("Please may {0} choose the node they want to move from and the node they want to move to.", currentPlayer.Name));
            Console.WriteLine(string.Format("Rememeber General {0} that you can fly to any empty node on the battle field (board).",currentPlayer.Name));
            return Console.ReadLine();
            
        }
        public string askToPlace()
        {
            Console.WriteLine(string.Format("Please may {0} choose a node to place their cows on", currentPlayer.Name));

            return Console.ReadLine();
            
        }

        public string askToMove()
        {
            Console.WriteLine(string.Format("Please may {0} choose the node they want to move from and the node they want to move to.", currentPlayer.Name));
            return Console.ReadLine();
           
        }
        #endregion

        #region Validation
        public bool validatePlacing (string input)
        {
            if (currentPlayer.numCowsToPlace() != 0)
            {
                INode inputNode = currentPlayer.getBoard().getNodeFromString(input);
                if (currentPlayer.getBoard().checkNodeExists(input) && currentPlayer.getBoard().checkNodeIsOccupied(inputNode) == false)
                    return true;
            }
            return false;
        }

        public bool validatePlacing (Node inputNode)
        {
            if (currentPlayer.numCowsToPlace() != 0)
            {
                if (currentPlayer.getBoard().checkNodeExists(inputNode.getPosition()) && currentPlayer.getBoard().checkNodeIsOccupied(inputNode) == false)
                    return true;
            }
            return false;
        }


        public bool validateMove(string position)
        {
            if (position.Length == 5 && position.Contains(" ") && currentPlayer.numCowsToPlace() == 0)
            {
                string start = getStartNode(position);
                string end = getEndNode(position);
                if (currentPlayer.getBoard().checkNodeExists(start) && currentPlayer.getBoard().checkNodeExists(end))
                {
                    INode startNode = currentPlayer.getBoard().getNodeFromString(start);
                    INode endNode = currentPlayer.getBoard().getNodeFromString(end);
                    if (currentPlayer.getBoard().checkNodeIsOccupied(startNode) == true && currentPlayer.getBoard().checkNodeIsOccupied(endNode) == false)
                    { 
                        if (startNode.Cow.Team == currentPlayer.Team)
                        {
                            if (currentPlayer.getBoard().isNeighbour(startNode, endNode))
                            {
                                return true;
                            }
                        }
                    }
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
        

        public bool validateFlying(string position)
        {
            if (position.Length == 5 && position.Contains(" ") && currentPlayer.getCowsAlive().Count == 3)
            {
                string start = getStartNode(position);
                string end = getEndNode(position);
                if (currentPlayer.getBoard().checkNodeExists(start) && currentPlayer.getBoard().checkNodeExists(end))
                {
                    INode startNode = currentPlayer.getBoard().getNodeFromString(start);
                    INode endNode = currentPlayer.getBoard().getNodeFromString(end);
                    if (currentPlayer.getBoard().checkNodeIsOccupied(startNode) == true && currentPlayer.getBoard().checkNodeIsOccupied(endNode) == false)
                    {
                        if (startNode.Cow.Team == currentPlayer.Team)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region MIllChecks
        public bool millFormed(INode JustChanged)
        {
            bool mill = false;
            int m = 0;
            if (!(currentPlayer.getBoard().numOfCowsOntheField(currentPlayer.Team) >= 3))
                return mill;

            List<List<string>> temp = getMillOptions(currentPlayer.getBoard().getMainNodeList().IndexOf(JustChanged));
            foreach (List<string> x in temp)
            {
                INode N1 = currentPlayer.getBoard().getNodeFromString(x[0]);
                INode N2 = currentPlayer.getBoard().getNodeFromString(x[1]);
                INode N3 = currentPlayer.getBoard().getNodeFromString(x[2]);
                if (N1.occupied && N2.occupied && N3.occupied)
                {
                    if (N1.Cow.Team == currentPlayer.Team && N2.Cow.Team == N1.Cow.Team && N3.Cow.Team == currentPlayer.Team)
                    {
                       if(checkToSeeIfMIllCanShoot(x) && m ==0) // this should make it so that if it is a partial mill that was formed then the player will not shoot
                        {
                            justGotMill = true;
                            m++;
                        }
                            currentPlayer.addMill(x);
                        mill = true;
                        
                    }
                    
                }
            }
            return mill;
        }

        private bool checkToSeeIfMIllCanShoot(List<string> newMIll)
        {
            if (currentPlayer.getMillList().Count > 0)
            {
                bool isNotPratialMill = false;
                foreach (List<string> x in currentPlayer.getMillList()) // run through all mills the current player has to see if any of the new mills cows are part of other mills
                {
                    if (x.Contains(newMIll[0]) || x.Contains(newMIll[1]) || x.Contains(newMIll[2]))
                    {
                        isNotPratialMill = false;
                        return isNotPratialMill;
                    }
                    else
                        isNotPratialMill = true;
                }
                return isNotPratialMill;
            }
            return true;
            
        }

        public bool AllEnemyCowInMill()
        {
            bool shootable = false;
            bool breakable2 = false;
            bool breakable = false; // this will allow us to break from the nested loop and return a true once a shootable cow has been found
            List<ICow> NumEnemyCowsOnfield = currentPlayer.getBoard().getCowsOnField(enemy.Team);
            foreach(ICow x in NumEnemyCowsOnfield)
            {
                foreach(List<string> y in enemy.getMillList())
                {
                    if (y.Contains(x.getPosition()))
                    {
                        breakable = true;
                        shootable = true;
                        breakable2 = false;
                    }
                    else
                    {
                        shootable = false;
                        breakable2 = true;
                    }
                    if (breakable)
                        break;
                }
                breakable = false;
                if (breakable2)
                    break;
            }
            
            return shootable;
        }

        private List<ICow> minusCows (List<ICow> livingcows, List<ICow> CowsStillPLacable) // change to get enmey cows on board.
        {
            if (CowsStillPLacable.Count == 0)
                return livingcows;
            foreach(ICow x in CowsStillPLacable)
            {
                livingcows.Remove(x);
            }
            return livingcows;
        }


        public void mill(INode placedNode)
        {
            if (millFormed(placedNode))
            {
                if (justGotMill)
                {
                    string cowToShoot = askToShoot();
                    INode temp = currentPlayer.getBoard().getNodeFromString(cowToShoot);
                    while (!(nodeChecks(temp)))
                    {
                        cowToShoot = askToShoot();
                        temp = currentPlayer.getBoard().getNodeFromString(cowToShoot);
                    }
                    shoot(cowToShoot);
                }

            }
          
        }

        ///<summary>
        ///this ask the use to shoot until a valid input is aquired.
        ///</summary>
        public string askToShoot()
        {
            Console.WriteLine("Please enter the node that you would like to shoot");
            string CowToShoot = Console.ReadLine(); // reads the user input
            CowToShoot.ToLower(); // changes it all to lower case :)
            if (currentPlayer.getBoard().checkNodeExists(CowToShoot) && CowToShoot.Length == 2) // this will check that the node exists
            {
                    return CowToShoot;
            }
            else
            {
                Console.WriteLine("A valid node only as a charecter length of 2 and also starts with a letter between a-g and a number between 1-6");
                while (!(currentPlayer.getBoard().checkNodeExists(CowToShoot) && CowToShoot.Length == 2)) // while loop will continue till correct node given
                                                                                       
                {
                    Console.WriteLine("Please enter the node that you would like to shoot");
                    CowToShoot = Console.ReadLine();
                    CowToShoot.ToLower();
                }
            }
            return CowToShoot;
        }

        public void shoot(string NodeChosen)
        {
            INode choosenNodeToShoot = currentPlayer.getBoard().getNodeFromString(NodeChosen);
            if(nodeChecks(choosenNodeToShoot) && justGotMill) // this will make sure that the node can be shoot at all
            {
               
                int index = enemy.getBoard().getMainNodeList().FindIndex(x => x.Position == choosenNodeToShoot.Position); // finds the index in the mainNodeList where this node is
                currentPlayer.ShootCow(index, enemy); // removes the cow at that node in the mainNodeList
                justGotMill = false;  
            }
        }

        public bool NodeInMill(INode node)
        {
            bool isNotInMill = true; // this method will check to see if the node choosen is in an enemy mill.
            foreach (List<string> x in enemy.getMillList())
            {
                if (x.Contains(node.Position))
                    return false;
                else
                    isNotInMill = true;
            }
            return isNotInMill;
        }

        public bool nodeChecks (INode node)
        {
            if (node.occupied) // make sure that the node is not empty
                if (node.Cow.Team == enemy.Team) // this will make sure that the node is not currentplayers own node
                    if (NodeInMill(node)) // this will check if the node is in a mill
                        return true;
                    else
                    {
                        if (AllEnemyCowInMill()) // this will make it so that if all enemy nodes are in a mill than the mill can be shoot at
                            return true;
                    }
                
            
            return false;


        }
        #endregion
    }
}
