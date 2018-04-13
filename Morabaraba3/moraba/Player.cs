using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public List<Cow> CowsLeft = new List<Cow> { };
        public List<List<string>> millList = new List<List<string>> { };

        public Team Team { get; set; }

        // default constructor

        // constructor
        public Player(string name, Team team)
        {
            Name = name;
            Team = team;
            makeCows(team);
        }

        private void makeCows(Team team)
        {
            for (int i = 0; i < 13; i++)
                CowsLeft.Add(new Cow(team));
        }    
        
        public int numCowsLeft ()
        {
            return CowsLeft.Count;
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
        public bool canShoot(List<Node> board, List<List<string>> enemyMills )
        {
            List<Cow> enemyCows = findEnemyCowsOnField(board);
            bool shoot = true;
            
            if (enemyMills.Count > 0 && enemyCows.Count > 0)
            {
                
                foreach (Cow x in enemyCows)
                {
                    foreach (List<string> y in enemyMills)
                    {
                        if (y.Contains(x.Position))
                        {
                            shoot = false;
                            break;

                        }
                        else
                            shoot = true;
                }
                }
            }

            return shoot;
        }

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
