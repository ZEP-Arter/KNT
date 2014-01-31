using System;

namespace GameLogic
{
	class RangedCharacter : SpecialCharacter
	{
		public RangedCharacter( string n, string path, int combat, List<Attributes> attr, int spec )
		{
			if( attr.Count != 0 )
				attr.Add(Attributes.RANGED);
			else
			{
				attr = new List<Attributes>();	
				attr.Add(Attributes.RANGED);
			}
			
			base(n, path, combat, attr);
			
			specialCombat = spec;
		}
		
		private int specialCombat;
		
	} // end class
} // end namespace