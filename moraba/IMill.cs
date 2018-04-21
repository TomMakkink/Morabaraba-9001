using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public interface IMill
    {
        bool millFormed(INode JustChanged);
        void mill(INode placedNode);
        string askToShoot();
        void shoot(string NodeChosen);
        bool NodeInMill(INode node);
        bool nodeChecks(INode node);
    }
}
