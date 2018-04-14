using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Umpire : IUmpire
    {
        public int turns;
        public Player currentPlayer;
        public Player enemy;
        public Board board;
        public Umpire(Board b)
        {
            turns = 1;
            board = b;
        }
        private List<List<string>> getMillOptions(int index)
        {
            string caseSwitch = board.getMainNodeList()[index].Position;

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

        public void play(Player player1, Player player2)
        {
            bool isWin = true;
            while (isWin)
            {
                if (turns % 2 == 1)
                {
                    currentPlayer = player1;
                    enemy = player2;

                }
                else
                {
                    currentPlayer = player2;
                    enemy = player1;
                }
                isWin = false;
            }
    
        }

        public bool millFormed(Node JustChanged)
        {
            bool mill = false;
            if (!(board.numOfCowsOntheField(currentPlayer.Team) >= 3))
                return mill;

            List<List<string>> temp = getMillOptions(board.mainNodeList.IndexOf(JustChanged));
            foreach (List<string> x in temp)
            {
                Node N1 = board.getNodeFromString(x[0]);
                Node N2 = board.getNodeFromString(x[1]);
                Node N3 = board.getNodeFromString(x[2]);
                if (N1.occupied && N2.occupied && N3.occupied)
                {
                    if (N1.Cow.Team == currentPlayer.Team && N2.Cow.Team == N1.Cow.Team && N3.Cow.Team == currentPlayer.Team)
                    {
                        currentPlayer.addMill(x);
                        mill = true;
                    }
                    
                }
            }
            return mill;
        }
        public bool AllEnemyCowInMill()
        {
            bool shootable = true; 
            bool breakable = false; // this will allow us to break from the nested loop and return a true once a shootable cow has been found
            List<Cow> NumEnemyCowsOnfield = minusCows(enemy.CowsAlive, enemy.CowsForPlacing);
            foreach(List<string> x in enemy.millList)
            {
                foreach(Cow y in NumEnemyCowsOnfield)
                {
                    if (x.Contains(y.Position))
                    {
                        shootable = false;
                    }
                    else
                    {
                        shootable = true;
                        breakable = true;
                    }
                    if (breakable)
                        break;
                }
                if (breakable)
                    break;
            }
            return shootable;
        }

        private List<Cow> minusCows (List<Cow> livingcows, List<Cow> CowsStillPLacable)
        {
            if (CowsStillPLacable.Count == 0)
                return livingcows;
            foreach(Cow x in CowsStillPLacable)
            {
                livingcows.Remove(x);
            }
            return livingcows;
        }

        public void mill(Node placedNode)
        {
            if (millFormed(placedNode))
            {
                // can shoot
            }
            else
            {
                //no mill formed
            }
        }

        public Player Win()
        {
            throw new NotImplementedException();
        }
    }
}
