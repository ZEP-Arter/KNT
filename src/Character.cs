using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    class SpecialCharacter : Things
    {
		//ctor
			public SpecialCharacter( string n, string path, int c, List<Attributes> attr)
			{
				base("SpecialCharater", n, path, c);
				
				attributes = attr;
			}
			
		//public
		
		//private members
		
			// special abilities
			private List<string> abilities; // maybe make this a class in itself ( 'abilities' ) not sure yet as to what the contain
    }

	public enum Attributes
	{
		FLYING, // triangel
		MAGIC, // drawn star
		CHARGE, //can charge in combat (large C)
		RANGED, // (large R)
		SPECIAL, // has special ability ( kleene star * )
		PLUS_HITS // paranthesis around combat score is multi hit in combat ( can take more then one hit in combat )
	}
}
