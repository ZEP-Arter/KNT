using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class Player
	{
		//ctor

        public Player(string n)
        {
            name = n;

            _position = NetworkPosition.HOST;

            turn = 0;
        }

        public Player(string n, NetworkPosition np)
        {
            name = n;

            _position = np;

            turn = 0;
        }

		//public
		
			public string getName()
			{ return name; }
		
			public void setName(string n)
			{ name = n; }

            public void setNetPosition(NetworkPosition pos)
            { _position = pos; }

            public NetworkPosition getNetPosition()
            { return _position; }

            public void setTurn(int turnNum)
            { turn = turnNum; }

            public int getTurn()
            { return turn; }

            public Thing getThingFromRack(int pos)
            {
                Thing thing = rack[pos];

                removeFromRack(thing);

                return thing;
            }

            public int getNumberOfOwnedTiles()
            {
                return ownedTiles.Count;
            }

            public int getNumberOfSpecialCharaters()
            {
                return characters.Count;
            }

            public List<Thing> getAllForts()
            {
                List<Thing> forts = new List<Thing>();

                foreach (Thing t in things)
                {
                    if (t.GetType().Equals("Fort"))
                        forts.Add(t);
                }

                return forts;
            }

            public List<Thing> getAllSpecialIncomeCounters()
            {
                List<Thing> sic = new List<Thing>();

                foreach (Thing t in things)
                {
                    if (t.GetType().Equals("Special Income"))
                        sic.Add(t);
                }

                return sic;
            }

        //private

            private void removeFromRack(Thing thing)
            {
                rack.Remove(thing);
            }
		
		//private members
		//
		//	name
			private string name;
        
        //  network position
            private NetworkPosition _position;

        //  turn position : since this is going to change I think it is best we have a var for it, not sure what type, keeping it as 'int' for now
            private int turn;

		//  things ( this will have to have a bool (isOnRack) // this is probs the things in play
            private List<Thing> things;
		//  characters ( for all non-special Characters this will also have to have a bool (isOnRacK)
            private List<SpecialCharacter> characters;
		// Rack
            private List<Thing> rack;
		// ( cannot keep gold counters, special characters, and forts )

        //tiles owned
            List<Tile> ownedTiles;
	}

    // @ericadamski : we may be able to get ride of this I am not sure yet :p
    public enum NetworkPosition
    {
        HOST,
        CLIENT
    }
}