using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IUmpire: IMill,inputValidation
    {
        void play();
        string askToFly();
        string askToPlace();
        bool AllEnemyCowInMill();
        string askToMove();

        IPlayer getCurrentPlayer();
        int getTurns();
        IPlayer getEnemy();
        bool win();
    }
}
