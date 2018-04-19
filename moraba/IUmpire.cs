using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum GameState {Placing, Moving, Flying };

    interface IUmpire
    {
        Player Win(Player Enemy);
        bool AllEnemyCowInMill();
        void play();
    }
}
