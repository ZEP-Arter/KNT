
using System.Collections.Generic;
namespace GameLogic.Things
{
    //THERE ARE 351 THINGS
    public class Thing
    {
        //Type of Thing:    Special Income, Creature, Magic, Treasure, Event, Gold Counter,
        //                  Fort, Control Marker, Special Character
		public Thing(string t, string n, List<Attributes.CombatAttributes> attr)
		{
			type = t;
			
			name = n;

            attributes = attr;
			
			isOwned = false;

            id = ThingNumber.getNextThingID();
		}

        public Thing() { }

        public string getType()
        {
            return this.type;
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

        public void setIsOwned(bool owned)
        {
            isOwned = owned;
        }

        public void setInBank(bool bank)
        {
            inBank = bank;
        }

        public void setOnRack(bool rack)
        {
            onRack = rack;
        }

		public int combatScore()
        { return combatValue; }

        public int getGoldValue()
        {
            if (goldValue == 0)
                return -1;

            return goldValue;
        }

        public int getID()
        {
            return id;
        }

        public bool isOnRack()
        {
            return onRack;
        }

        public bool isInBank()
        {
            return inBank;
        }

        public string getHexType()
        {
            return hexType;
        }

		protected void setName(string n)
		{ name = n; }
			
		protected void setCombatScore(int score)
		{ combatValue = score; }


        string type;

        string name;

        protected string hexType; //if applicable

        //this needs some sort of image
		//private string image_path = "";

        protected int combatValue; //if applicable

        bool inBank;

        bool onRack;

		bool isOwned;

        private int id;

        int goldValue; //if applicable

        public List<Attributes.CombatAttributes> attributes; //if applicable
    }

    public static class ThingNumber
    {
        public static int getNextThingID()
        {
            return (++numThings);
        }

        private static int numThings = 0;
    }
}
