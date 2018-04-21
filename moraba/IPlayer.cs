using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public enum Team { DarkCow, LightCow };
     public interface IPlayer:IMove 
    {
        
        
        string Name { get; }
        Team Team { get; }

        int numCowsAlive();


        int numCowsToPlace();

        void removePlacedCow();


        void killCow(string pos);


        void GiveCowName(string x);


        void ChangeCowName(string oldName, string newName);

        void addMill(List<string> newMill);

        List<List<string>> getMillList();

        List<ICow> getCowsAlive();

        INode getLastNode();

        IBoard getBoard();

        List<ICow> getPlacingCows();


        string getName();

        void ShootCow(int index, IPlayer en);

        void GetRidOfMill(string pos);

    }

}
