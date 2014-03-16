using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNT_Client.Networkable
{
    public class Tile
    {
        public Tile(KNT_ServiceReference.Tile t)
        { that = t; }

        public bool getCFlag()
        { return that._combatFlagged; }

        public Player getPlayer()
        { return new Player(that._playerControl); }

        public Player getPlayerAble()
        { return new Player(that._playerAbleToStart); }

        public bool getPlayerControlBool()
        { return that._playerControlBool; }

        public int[] getSurrounding()
        { return new int[] { that._nHex, that._neHex, that._seHex, that._sHex, that._swHex, that._nwHex }; }

        public int getHexNum()
        { return that._hexNumber; }

        public string getHexType()
        { return that._hexType; }

        public void resetMovementLogic()
        { that._traversed = false; }

        public bool isRough()
        { return that._rough; }

        public bool getFaceUp()
        { return that._faceUp; }

        public bool getStart()
        { return that._startPossible; }

        public void flipTile()
        { that._faceUp = true; }

        public int getFortLevel()
        { return that._fortLevel; }

        public Dictionary<int, List<Thing>> getStacks()
        { 
            Dictionary<int, List<Thing>> cpy = new Dictionary<int, List<Thing>>();

            foreach(int num in that._stacks.Keys)
                foreach (KNT_ServiceReference.Thing t in that._stacks[num])
                {
                    if (cpy.ContainsKey(num))
                        cpy[num].Add(new Thing(t));
                    else
                    {
                        cpy.Add(num, new List<Thing>());
                        cpy[num].Add(new Thing(t));
                    }
                }

            return cpy;
        }

        public bool isTraversed()
        { return that._traversed; }

        KNT_ServiceReference.Tile that;
    }
}
