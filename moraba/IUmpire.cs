using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{


    interface IUmpire
    {
        Player Win(Player Enemy);
        bool AllEnemyCowInMill();
        void play(Player player1, Player player2);
    }
}
