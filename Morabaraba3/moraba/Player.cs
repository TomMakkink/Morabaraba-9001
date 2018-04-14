using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public List<Cow> CowsAlive = new List<Cow> { };
        public List<Cow> CowsForPlacing = new List<Cow> { };
        public List<List<string>> millList = new List<List<string>> { };

        public Team Team { get; set; }

        // default constructor

        // constructor
        public Player(string name, Team team)
        {
            Name = name;
            Team = team;
            BreedCows(team);
        }
        public void makeCowsToPlace(Team team)
        {
            for (int i = 0; i < 12; i++)
                CowsForPlacing.Add(new Cow(team));
        }
        private void BreedCows(Team team)
        {
            for (int i = 0; i < 12; i++)
                CowsAlive.Add(new Cow(team));

            
        }    
        
        public int numCowsAlive ()
        {
            return CowsAlive.Count;
        }

        public int numCowsToPlace()
        {
            return CowsForPlacing.Count;
        }
        public void placedCow()
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
        }
        public void addMill (List<string> newMill)
        {
            millList.Add(newMill);
        }

        /// <summary>
        /// This method will check to see if there is a cow for the player to shoot at or if they just need to move on.
        /// Need the mainNodeList (board), you need the millList of the enemy)
        /// </summary>
        /// <param name="b"></param>
        /// <param name=""></param>
        /// <returns></returns>
       

        private List<Cow> findEnemyCowsOnField(IEnumerable<Node> board)
        {
            List<Cow> temp = new List<Cow> { };
            foreach(Node x in board)
            {
                if (x.Cow != null)
                    if (x.Cow.Team != Team)
                        temp.Add(x.Cow);
            }

            return temp;
        }

    }
}
