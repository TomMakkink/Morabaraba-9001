using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum Team { DarkCow, LightCow };
    interface IPlayer
    {
        
        bool canShoot(List<Node> board, List<List<string>> enemyMIlls);
        string Name { get; }
        Team Team { get; }
        
    }

}
