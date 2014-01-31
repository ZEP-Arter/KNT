using System;

namespace GameLogic
{
	class FlyingCharacter : SpecialCharacter
	{
		public FlyingCharacter( string n, int combat, List<Attributes> attr )
		{
			if( attr. )
				attr.Add(Attributes.FLYING);
			else
			{
				attr = new List<Attributes>();	
			}
			
			base(n, combat, attr);
		}
		
	} // end class
} // end namespace