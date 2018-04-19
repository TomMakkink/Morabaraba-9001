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




        int numCowsAlive();


        int numCowsToPlace();

        void removePlacedCow();


        void killCow(string pos);


        void GiveCowName(string x);


        void ChangeCowName(string oldName, string newName);

        void addMill(List<string> newMill);


        List<Cow> getCowsAlive();


        List<Cow> getPlacingCows();


        string getName();
       
    }

}
