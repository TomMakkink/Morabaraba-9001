using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum Team { DarkCow, LightCow };
    interface IPlayer
    {
        
        
        string Name { get; }
        Team Team { get; }
        
    }

}
