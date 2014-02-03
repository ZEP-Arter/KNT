using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    class Creature : Things
    {
		//ctor
        public Creature(string name, string path, string hex, int c, List<Attributes> attr)
        {
            base("Creature", name, path);
            hexType = hex;
            combatValue = c
            attributes = attr;
        }
			
		//public
		
		//private members
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