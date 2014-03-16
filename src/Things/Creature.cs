using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Things
{
    class Creature : Thing
    {
		//ctor
        public Creature(string name, string hex, int c, List<Attributes.CombatAttributes> attr)
            : base("Creature", name, attr)
        {
            hexType = hex;
            combatValue = c;
        }
			
		//public
		
		//private members
    }
}