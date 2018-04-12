using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface IBoard
    {
        IEnumerable<INode> mainNode(string Position);

    }
}
