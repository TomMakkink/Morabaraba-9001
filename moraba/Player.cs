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
        private Node LastEditedNode;
        private Board BoardList;

        public Team Team { get; set; }

        // constructor
        public Player(string name, Team team, Board board)
        {
            Name = name;
            Team = team;
            BoardList = board;
            makeCowsToPlace(team);
        }

#region IPLayer
        public Board getBoard ()
        {
            return BoardList;
        }

        private void makeCowsToPlace(Team team)
        {
            for (int i = 0; i < 12; i++)
            {
                CowsAlive.Add(new Cow(team));
                CowsForPlacing.Add(new Cow(team));
            }
        }

        public int numCowsAlive()
        {
            return CowsAlive.Count;
        }

        public int numCowsToPlace()
        {
            return CowsForPlacing.Count;
        }
        public void removePlacedCow()
        {
            if (CowsForPlacing.Count > 0)
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

        public void ChangeCowName(string oldName, string newName)
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

        public void addMill(List<string> newMill)
        {
            millList.Add(newMill);
        }

        public List<Cow> getCowsAlive()
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

        public Node getLastNode()
        {
            return LastEditedNode;
        }

        public List<List<string>> getMillList()
        {
            return millList;
        }
        #endregion


        #region Moving
        public bool Placing(string placeNode)
        {

            Node temp = BoardList.getNodeFromString(placeNode);
            if (!BoardList.checkNodeIsOccupied(temp))
            {
                int index = BoardList.getMainNodeList().FindIndex(x => x.Position == placeNode);
                BoardList.getMainNodeList()[index].addCow(CowsForPlacing[0]);
                LastEditedNode = BoardList.getMainNodeList()[index];
                GiveCowName(LastEditedNode.Position);
                removePlacedCow();
                return true;
            }
            return false;
        }


        public void moveCow(Node startNode, Node endNode)
        {
            int startIndex = BoardList.getMainNodeList().FindIndex(x => x.Position == startNode.Position);
            int endIndex = BoardList.getMainNodeList().FindIndex(x => x.Position == endNode.Position);

            BoardList.getMainNodeList()[endIndex].addCow(startNode.Cow);
            BoardList.getMainNodeList()[endIndex].Cow.Position = BoardList.getMainNodeList()[endIndex].Position;
            ChangeCowName(BoardList.getMainNodeList()[startIndex].Position, BoardList.getMainNodeList()[endIndex].Position);
            BoardList.getMainNodeList()[startIndex].removeCow();
            LastEditedNode = BoardList.getMainNodeList()[endIndex];
        }
        #endregion
    }

}
