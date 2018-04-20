using System;
using System.Collections.Generic;
using System.Text;

namespace moraba
{
    public interface ICow
    {
        string getPosition();

        Team Team { get; }

        void changePosition(string x);

    }
}
