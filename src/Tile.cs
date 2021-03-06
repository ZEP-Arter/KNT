using GameLogic.Managers;
using GameLogic.Things;
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
        private bool faceUp = true;
        //Shows whether the Tile can be selected as a starting point
        private bool startPossible = false;
        //Holds stacks of things for each player
        public Dictionary<int, List<Thing>> stacks = new Dictionary<int,List<Thing>>();
        public Dictionary<int, bool> movePossible = new Dictionary<int, bool>();

        //For Level is 0 if there is no Fort
        private int fortLevel = 0;

        private bool combatFlagged = false;
        private bool rough = false;

        private bool playerControlBool = false;

		private Player playerControl = null;
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
            stacks.Add(1, new List<Thing>());
            stacks.Add(2, new List<Thing>());
            stacks.Add(3, new List<Thing>());
            stacks.Add(4, new List<Thing>());
            movePossible.Add(1, true);
            movePossible.Add(2, true);
            movePossible.Add(3, true);
            movePossible.Add(4, true);

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
            movePossible.Add(1, true);
            movePossible.Add(2, true);
            movePossible.Add(3, true);
            movePossible.Add(4, true);

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
            List<Tile> tList = GameBoard.Game.getMap().getHexList();
            foreach (Tile t in tList)
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

        public bool adjacencyRule(Player p)
        {
            List<Tile> tList = GameBoard.Game.getMap().getHexList();
            if ((nHex == 0 || tList[nHex - 1].getPlayer() == null || tList[nHex - 1].getPlayer() == p) &&
                (neHex == 0 || tList[neHex - 1].getPlayer() == null || tList[neHex - 1].getPlayer() == p) &&
                (seHex == 0 || tList[seHex - 1].getPlayer() == null || tList[seHex - 1].getPlayer() == p) &&
                (sHex == 0 || tList[sHex - 1].getPlayer() == null || tList[sHex - 1].getPlayer() == p) &&
                (swHex == 0 || tList[swHex - 1].getPlayer() == null || tList[swHex - 1].getPlayer() == p) &&
                (nwHex == 0 || tList[nwHex - 1].getPlayer() == null || tList[nwHex - 1].getPlayer() == p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool doesPlayerHaveStack(int i)
        {
            if (stacks[i].Count == 0)
                return false;
            else
                return true;
        }

        public List<Thing> getPlayerStack(int i)
        {
            return stacks[i];
        }

        public void clearPlayerStack(int i)
        {
            stacks[i] = new List<Thing>();
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

        public void upgradeFort() { fortLevel++; }
        public int getFort() { return fortLevel; }
       
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
