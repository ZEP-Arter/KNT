
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace GameLogic
{
    //THERE ARE 351 THINGS
    [DataContract(IsReference = false)]
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

		protected void setName(string n)
		{ name = n; }
			
		protected void setCombatScore(int score)
		{ combatValue = score; }


        [DataMember]
        string type;

        [DataMember]
        string name;

        [DataMember]
        protected string hexType; //if applicable

        //this needs some sort of image
		private string image_path = "";

        [DataMember]
        protected int combatValue; //if applicable

        [DataMember]
        bool inBank;

        [DataMember]
        bool onRack;

        [DataMember]
		bool isOwned;


        [DataMember]
        private int id;


        [DataMember]
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
