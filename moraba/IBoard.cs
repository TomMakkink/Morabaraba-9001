using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
     public interface IBoard
    {
        List<INode> getMainNodeList ();

        void printBoard();

        INode getNodeFromString(string node);

        void RemoveCow(int index, IPlayer player);

        bool checkNodeExists(string str);

        bool isNeighbour(INode startNode, INode endNode);

        int numOfCowsOntheField();

        int numOfCowsOntheField(Team team);

        bool checkNodeIsOccupied(INode node);

        bool checkNodeIsOccupied(int index);

    }
}
