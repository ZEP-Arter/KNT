using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT.GUI;

namespace GameLogic
{
    abstract class SpecialCharacter : IImage
    {
		//ctor
			public SpecialCharacter( string n, int c, List<Attributes> attr)
			{
				name = n;
				
				abilities = ab;
				
				combatScore = c;
				
				attributes = attr;
				
				isOwned = false;
			}
		//public
		
			public bool getIsOwned()
			{ return isOwned; }
			
			public string getName()
			{ return name; }
			
			public void setOwned()
            {
                if (isOwned)
                    isOwned = false;
                else
                    isOwned = true;
            }
		
		//private
		
		//protected
			protected void setName(string n)
			{ name = n; }
			
			protected void setCombatScore(int score)
			{ combatScore = score; }
		
		//private members
		
			// special abilities
			private List<string> abilities; // maybe make this a class in itself ( 'abilities' ) not sure yet as to what the contain
			
			// combat score
			private int combatScore;
			
			// character name/type
			private string name;
			
			//is owned by a player ( not in pool next to the bank)
			private bool isOwned;

            //this needs some sort of image
    }

	public enum Attributes
	{
		FLYING, // triangel
		MAGIC_USING, // drawn star
		CHARGE, //can charge in combat (large C)
		RANGED, // (large R)
		SPECIAL, // has special ability ( kleene star * )
		PLUS_HITS // paranthesis around combat score is multi hit in combat ( can take more then one hit in combat )
	}
}
