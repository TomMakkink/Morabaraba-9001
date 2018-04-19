using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer, IMove
    {
        public string Name { get; private set; }

        private List<Cow> CowsAlive = new List<Cow> { };
        private List<Cow> CowsForPlacing = new List<Cow> { };
        private List<List<string>> millList = new List<List<string>> { };
        private Board Board;

        public Team Team { get; set; }

        // default constructor

        // constructor
        public Player(string name, Team team, Board board)
        {
            Name = name;
            Team = team;
            Board = board; 
            makeCowsToPlace(team);
        }
#region IPLayer
        private void makeCowsToPlace(Team team)
        {
            for (int i = 0; i < 12; i++)
            {
                CowsAlive.Add(new Cow(team));
                CowsForPlacing.Add(new Cow(team));
            }
        }
          
        public int numCowsAlive ()
        {
            return CowsAlive.Count;
        }

        public int numCowsToPlace()
        {
            return CowsForPlacing.Count;
        }
        public void removePlacedCow()
        {
            if (CowsForPlacing.Count>0)
                CowsForPlacing.RemoveAt(0);
        }

        public void killCow(string pos)
        {
            foreach (Cow x in CowsAlive)
            {
                if (x.Position == pos)
                {
                    CowsAlive.Remove(x);
                    break;
                }
            }
            GetRidOfMill(pos);
        }

        public void GiveCowName(string x)
        {
            CowsAlive[0].Position = x;
            Cow temp = CowsAlive[0];
            CowsAlive.RemoveAt(0);
            CowsAlive.Add(temp);
        }

        public void ChangeCowName(string oldName , string newName)
        {
            int index = CowsAlive.FindIndex(y => y.Position == oldName);
            CowsAlive[index].Position = newName;
        }

        private void GetRidOfMill(string pos)
        {
            foreach (List<string> x in millList)
            {
                if (x.Contains(pos))
                {
                    millList.Remove(x);
                   
                }
            }
        }

        public void addMill (List<string> newMill)
        {
            millList.Add(newMill);
        }

        public List<Cow> getCowsAlive ()
        {
            return CowsAlive;
        }

        public List<Cow> getPlacingCows()
        {
            return CowsForPlacing;
        }

        public string getName()
        {
            return Name;
        }
        #endregion
        #region Moving
        public bool Placing(string placeNode, Player player)
        {
            if (checkNodeExists(placeNode) && player.numCowsToPlace() > 0)
            {
                Node temp = getNodeFromString(placeNode);
                if (!checkNodeIsOccupied(temp))
                {
                    int index = mainNodeList.FindIndex(x => x.Position == placeNode);
                    mainNodeList[index].addCow(player.CowsForPlacing[0]);
                    LastEditedNode = mainNodeList[index];
                    player.GiveCowName(LastEditedNode.Position);
                    player.placedCow();
                    return true;
                }
            }
            return false;
        }

        public bool Moving(string position, Player player)
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

        public void moveCow(Node startNode, Node endNode, Player player)
        {
            int startIndex = mainNodeList.FindIndex(x => x.Position == startNode.Position);
            int endIndex = mainNodeList.FindIndex(x => x.Position == endNode.Position);

            mainNodeList[endIndex].addCow(startNode.Cow);
            mainNodeList[endIndex].Cow.Position = mainNodeList[endIndex].Position;
            player.ChangeCowName(mainNodeList[startIndex].Position, mainNodeList[endIndex].Position);
            mainNodeList[startIndex].removeCow();
            LastEditedNode = mainNodeList[endIndex];
        }

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
        #endregion
    }
}
