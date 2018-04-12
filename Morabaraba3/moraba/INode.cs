using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    interface INode
    {
        void addCow(ICow cow);

        void removeCow();

        void getNeighbours();


    }
}
