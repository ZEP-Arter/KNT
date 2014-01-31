using KNT.GUI;

namespace GameLogic
{
    //THERE ARE 351 THINGS
    public class Thing : IImage
    {
        //Type of Thing:    Special Income, Creature, Magic, Treasure, Event, Gold Counter,
        //                  Fort, Control Marker, Special Character
		public Thing(string t, string n, string path, int combat)
		{
			type = t;
			
			name = n;
			
			combatValue = combat;
			
			isOwned = false;
			
			image_path = path;
		}
		
		
		
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

		public int combatScore()
		{ return combatValue; }

		protected void setName(string n)
		{ name = n; }
			
		protected void setCombatScore(int score)
		{ combatValue = score; }

        string type;
        string name;
        string hexType; //if applicable

        //this needs some sort of image
		private const string image_path;

        int combatValue; //if applicable

        bool inBank;
        bool onRack;
		bool isOwned;

        int goldValue; //if applicable

        string attribute; //if applicable
    }
}
