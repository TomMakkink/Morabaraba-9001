using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum GameState {Placing, Moving, Flying };

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
        IPlayer Win(IPlayer enemy);
    }
}
