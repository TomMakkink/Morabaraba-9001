using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum GameState {Placing, Moving, Flying };

    interface IUmpire
    {
        
        void play();
        string askToFly();
        string askToPlace();
        bool AllEnemyCowInMill();
        string askToMove();
        bool validatePlacing(string input);
        bool validateMove(string position);
        string getStartNode(string input);
        string getEndNode(string input);
        bool validateFlying(string position);
        bool millFormed(INode JustChanged);
        void mill(INode placedNode);
        string askToShoot();
        void shoot(string NodeChosen);
        bool NodeInMill(INode node);
        bool nodeChecks(INode node);
        IPlayer getCurrentPlayer();
        int getTurns();
        IPlayer getEnemy();
        IPlayer Win(IPlayer enemy);
    }
}
