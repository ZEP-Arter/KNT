using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public abstract class Phase
    {
        public Phase(string n)
        {
            name = n;
        }

        string name;

        enum State
        {
            BEGIN,
            IN_PROGRESS,
            END
        }
    }
}
