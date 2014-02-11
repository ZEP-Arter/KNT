using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class Player : IComparable
	{
		//ctor

        public Player(string n, int yPos)
        {
            name = n;

            _position = NetworkPosition.HOST;

            turn = 0;

            goldY = yPos;

            gold = 10;

            mymarkers = new Dictionary<int,bool>();

            diceRoll = 0;

            ownedTiles = new List<Tile>();

            things = new List<Thing>();

            rack = new List<Thing>();

            holdingMarker = false;

            inPhase = false;
        }

        public Player(string n, NetworkPosition np, int yPos)
        {
            name = n;

            _position = np;

            turn = 0;

            gold = 10;

            goldY = yPos;

            mymarkers = new Dictionary<int, bool>();

            diceRoll = 0;

            ownedTiles = new List<Tile>();

            things = new List<Thing>();

            rack = new List<Thing>();

            holdingMarker = false;

            inPhase = false;
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

            public int getPlayerGold()
            {
                return gold;
            }

            public void givePlayerGold(int amount)
            {
                gold += amount;
            }

            public void AddThingToRack(Thing thing)
            {
                rack.Add(thing);
            }

            public int CompareTo(Object toCompare)
            {
                if (this.turn < ((Player)toCompare).turn)
                    return 1;

                return -1;
            }

            public int getGold()
            {
                return gold;
            }

            public bool containsMarkerID(int id)
            {
                return mymarkers.ContainsKey(id);
            }

            public void addMarkerID(int id)
            {
                mymarkers.Add(id, false);
            }

            public void placeMarker(int id)
            {
                mymarkers[id] = true;
            }

            public int getDiceRoll()
            {
                return diceRoll;
            }

            public void setDiceRoll(int roll)
            {
                diceRoll = roll;
            }

            public bool placedAllMarkers()
            {
                return !mymarkers.ContainsValue(false);
            }

            public bool handsFull()
            {
                return holdingMarker;
            }

            public void setHandsFull()
            {
                if (holdingMarker)
                    holdingMarker = false;
                else
                    holdingMarker = true;
            }

            public bool getInPhase()
            {
                return inPhase;
            }

            public void donePhase()
            {
                inPhase = true;
            }

            public void startPhase()
            {
                inPhase = false;
            }

            public void addOwnedTile(Tile hex)
            {
                ownedTiles.Add(hex);
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
            private int diceRoll;

		//  things ( this will have to have a bool (isOnRack) // this is probs the things in play
            private List<Thing> things;
		//  characters ( for all non-special Characters this will also have to have a bool (isOnRacK)
            private List<SpecialCharacter> characters;
		// Rack
            private List<Thing> rack;
		// ( cannot keep gold counters, special characters, and forts )

        //tiles owned
            List<Tile> ownedTiles;

        //total gold pieces
            private int gold;

        // position of gold on scree
            public const int goldX = 660;
            public int goldY; // set at runtime;

        // marker id's and has been placed
            Dictionary<int, bool> mymarkers;

        //holding marker
            bool holdingMarker;

        //currently not done playing phase
            bool inPhase;
    }

    // @ericadamski : we may be able to get ride of this I am not sure yet :p
    public enum NetworkPosition
    {
        HOST,
        CLIENT
    }
}