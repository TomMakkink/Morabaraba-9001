using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum Team { DarkCow, LightCow };
    public enum GameState { Placing, Moving, Flying };
    interface IPlayer
    {
       
        string Name { get; }
        Team Team { get; }

        GameState State { get; }

        GameState getState();

        void setState( GameState stat);
        
    }

}
