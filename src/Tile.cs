using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GameLogic.Managers;

namespace GameLogic
{
    //THERE ARE 48 TILES
    //NUMBER OF TILES ON A 4 PLAYER BOARD IS 37
    [DataContract(IsReference = false)]
    public class Tile
    {
        //Hex Number
        [DataMember]
        private int hexNumber;
        
        //Number for connected hexes

        [DataMember]
        private int nHex;

        [DataMember]
        private int neHex;

        [DataMember]
        private int seHex;

        [DataMember]
        private int sHex;

        [DataMember]
        private int swHex;

        [DataMember]
        private int nwHex;
        //Type of Hex: Jungle, Frozen Waste, Desert, Plains, Forest, Sea, Swamp, Mountain

        [DataMember]
        private string hexType;
        //Shows whether the Tile is face up or face down

        [DataMember]
        private bool faceUp = true;
        //Shows whether the Tile can be selected as a starting point

        [DataMember]
        private bool startPossible = false;
        //Holds stacks of things for each player

        public Dictionary<int, List<Thing>> stacks = new Dictionary<int,List<Thing>>();

        [DataMember]
        public List<Thing> p1Stack;

        [DataMember]
        public List<Thing> p2Stack;

        [DataMember]
        public List<Thing> p3Stack;

        [DataMember]
        public List<Thing> p4Stack;

        //For Level is 0 if there is no Fort

        [DataMember]
        private int fortLevel = 0;

        [DataMember]
        private bool combatFlagged = false;

        [DataMember]
        private bool rough = false;

        [DataMember]
        private bool playerControlBool = false;

        [DataMember]
        private Player playerControl = null;

        [DataMember]
        private Player playerAbleToStart = null;

        //Movement logic variable
        [DataMember]
        public bool traversed = false;
        
        //Constructor
        public Tile(int n, int[] a, string h)
        {
            hexNumber   = n;
            nHex        = a[0];
            neHex       = a[1];
            seHex       = a[2];
            sHex        = a[3];
            swHex       = a[4];
            nwHex       = a[5];
            hexType     = h;
            stacks.Add(1, new List<Thing>());
            stacks.Add(2, new List<Thing>());
            stacks.Add(3, new List<Thing>());
            stacks.Add(4, new List<Thing>());

            if(h == "Swamp" || h == "Forest" || h == "Mountain" || h == "Jungle")
                rough = true;
        }
        
        public Tile(int n, int[] a, string h, bool s)
        {
            hexNumber   = n;
            nHex        = a[0];
            neHex       = a[1];
            seHex       = a[2];
            sHex        = a[3];
            swHex       = a[4];
            nwHex       = a[5];
            hexType     = h;
            stacks.Add(1, new List<Thing>());
            stacks.Add(2, new List<Thing>());
            stacks.Add(3, new List<Thing>());
            stacks.Add(4, new List<Thing>());
            if(h == "Swamp" || h == "Forest" || h == "Mountain" || h == "Jungle")
                rough = true;
            startPossible = s;
        }

        public void setPlayerControl(Player p)
        {
            setPlayerControlBool(true);
            playerControl = p;
        }

        public void selectedAsStarting(Player p)
        {
            playerControl = p;
            setPlayerControlBool(true);
            foreach (Tile t in GameBoard.Game.getMap().getHexList())
            {
                int hNum = t.getHexNum();
                if (hNum == nHex || hNum == neHex || hNum == seHex ||
                    hNum == sHex || hNum == swHex || hNum == nwHex)
                {
                    if (t.getPlayerAble() == null)
                        t.setPlayerAble(p);
                }
            }
        }

        public bool doesPlayerHaveStack(int i)
        {
            if (stacks[i].Count == 0)
                return false;
            else
                return true;
        }

        public void addToPlayerStack(int i, Thing thing)
        {
            if (stacks.ContainsKey(i))
                stacks[i].Add(thing);
            else
            {
                List<Thing> temp = new List<Thing>();
                temp.Add(thing);
                stacks.Add(i, temp);
            }
        }
       
        public void setPlayerAble(Player p) { playerAbleToStart = p; }
        public void setPlayerControlBool(bool b) { playerControlBool = b; }
        public void setCFlag(bool b) { combatFlagged = b; }

        public bool getCFlag() { return combatFlagged; }
        public Player getPlayer() { return playerControl; }
        public Player getPlayerAble() { return playerAbleToStart; }
        public bool getPlayerControlBool() { return playerControlBool; }
        public int[] getSurrounding() { return new int[] { nHex, neHex, seHex, sHex, swHex, nwHex }; }
        public int getHexNum() { return hexNumber; }
        public string getHexType() { return hexType; }
        public void resetMovementLogic() { traversed = false; }
        public bool isRough() { return rough; }
        public string getType() { return hexType; }
        public bool getFaceUp() { return faceUp; }
        public bool getStart() { return startPossible; }
        public void flipTile() { faceUp = true; }
        public int getFortLevel() { return fortLevel; }

    }
}
