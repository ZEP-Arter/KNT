using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Things
{
    class SpecialCharacter : Thing
    {
		//ctor
        public SpecialCharacter(string n, int c, List<Attributes.CombatAttributes> attr) : 
				base("SpecialCharacter", n, attr)
			{
                
                combatValue = c;
			}
			
		//public
		
		//private members
		
			// special abilities
			//private List<string> abilities; // maybe make this a class in itself ( 'abilities' ) not sure yet as to what the contain
    }
}
