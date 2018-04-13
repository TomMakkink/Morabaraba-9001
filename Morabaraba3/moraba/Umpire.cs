using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
  public  class Umpire : IUmpire
    {
        public int turns;
        public Player currentPlayer;
        public Player enemy;

        public Umpire()
        {
            turns = 1;
        }
        public bool isDraw()
        {
            throw new NotImplementedException();
        }

        public void play(Player player1, Player player2)
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
        }

        public Player Win()
        {
            throw new NotImplementedException();
        }
    }
}
