using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IUmpire
    {
        Player Win();
        bool AllEnemyCowInMill();
        void play(Player player1, Player player2);
    }
}
