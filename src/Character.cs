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
			public SpecialCharacter( string n, List<string> ab )
			{
				name = n;
				
				abilities = ab;
				
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
		
		//private members
		
			// special abilities
			private List<string> abilities; // maybe make this a class in itself ( 'abilities' ) not sure yet as to what the contain
			
			// character name/type
			private string name;
			
			//is owned by a player ( not in pool next to the bank)
			private bool isOwned;

            //this needs some sort of image
    }
}
