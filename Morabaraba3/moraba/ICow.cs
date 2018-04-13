using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface ICow
    {
        bool isShootable(IEnumerable<Node> nodeBoard);

        string Position { get; }

        Team Team { get; }
    }
}
