using System;
using System.Collections.Generic;
namespace GameLogic
{
    //THERE ARE 48 TILES
    //NUMBER OF TILES ON A 4 PLAYER BOARD IS 37
    public class Tile
    {
        //Hex Number
        private int hexNumber;
        
        //Number for connected hexes
        private int nHex;
        private int neHex;
        private int seHex;
        private int sHex;
        private int swHex;
        private int nwHex;
        //Type of Hex: Jungle, Frozen Waste, Desert, Plains, Forest, Sea, Swamp, Mountain
        private string hexType;
        //Shows whether the Tile is face up or face down
        private bool faceUp = false;
        //Shows whether the Tile can be selected as a starting point
        private bool startPossible = false;
        //Holds stacks of things for each player
        public List<Thing> p1Stack;
        public List<Thing> p2Stack;
        public List<Thing> p3Stack;
        public List<Thing> p4Stack;
        
        private bool rough = false;

		private Player playerControl;
        
        //Movement logic variable
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
            if(h == "Swamp" || h == "Forest" || h == "Mountain" || h == "Jungle")
                rough = true;
            startPossible = s;
        }

        public int[] getSurrounding() { return new int[] { nHex, neHex, seHex, sHex, swHex, nwHex }; }
        public int getHexNum() { return hexNumber; }
        public void resetMovementLogic() { traversed = false; }
        public bool isRough() { return rough; }
        public string getType() { return hexType; }
        public bool getFaceUp() { return faceUp; }
        public bool getStart() { return startPossible; }
        public void flipTile() { faceUp = true; }

    }
}
