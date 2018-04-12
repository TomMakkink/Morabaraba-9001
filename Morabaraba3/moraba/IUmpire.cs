using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IUmpire
    {
        IPlayer Win();
        bool isDraw();
        void play();
    }
}
