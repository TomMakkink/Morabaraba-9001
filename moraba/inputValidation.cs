using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public interface inputValidation
    {


        bool validatePlacing(string input);
    
        bool validateMove(string position);
       
        string getStartNode(string input);

        string getEndNode(string input);

        bool validateFlying(string position);
    }
}
