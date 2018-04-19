using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer
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
      

    }
}
