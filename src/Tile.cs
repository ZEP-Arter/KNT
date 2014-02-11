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

        //For Level is 0 if there is no Fort
        private int fortLevel = 0;

        private bool combatFlagged = false;
        private bool rough = false;

        private bool playerControlBool = false;

		private Player playerControl;
        private Player playerAbleToStart = null;
        
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
       
        public void setPlayerAble(Player p) { playerAbleToStart = p; }
        public void setPlayerControlBool(bool b) { playerControlBool = b; }
        public void setCFlag(bool b) { combatFlagged = b; }

        public bool getCFlag() { return combatFlagged; }
        public Player getPlayer() { return playerControl; }
        public Player getPlayerAble() { return playerAbleToStart; }
        public bool getPlayerControlBool() { return playerControlBool; }
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
