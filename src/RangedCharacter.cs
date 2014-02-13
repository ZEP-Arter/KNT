using System;
using System.Collections.Generic;

namespace GameLogic
{
	class RangedCharacter : SpecialCharacter
	{
		public RangedCharacter( string n, int combat, List<Attributes.CombatAttributes> attr, int spec ) :
			base(n, combat, attr)
		{
			if( attr.Count != 0 )
                attr.Add(Attributes.CombatAttributes.RANGED);
			else
			{
                attr = new List<Attributes.CombatAttributes>();
                attr.Add(Attributes.CombatAttributes.RANGED);
			}
			
			specialCombat = spec;
		}
		
		private int specialCombat;
		
	} // end class
} // end namespace