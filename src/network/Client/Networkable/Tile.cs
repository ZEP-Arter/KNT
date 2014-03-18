using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNT_Client.Networkable
{
    public class Tile
    {
        public Tile(KNT_ServiceReference.Tile t)
        { 
            that = t;

            stacksCpy = new Dictionary<int, List<Thing>>();
        }

        #region Public_Methods

        public bool getCFlag()
        { return that._combatFlagged; }

        public Player getPlayer()
        { return new Player(that._playerControl); }

        public Player getPlayerAble()
        { return new Player(that._playerAbleToStart); }

        public void setPlayerAble(KNT_ServiceReference.Player player)
        { that._playerAbleToStart = player; }

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

        public bool isTraversed()
        { return that._traversed; }

        public Dictionary<int, List<Thing>> getStacks()
        { return stacksCpy; }

        public void selectedAsStarting(Player player)
        {
            that._playerControl = player.getBase();
            that._playerControlBool = true;

            foreach (Tile t in GameController.Game.getMap().getHexList())
            {
                int hNum = t.getHexNum();
                int[] around = t.getSurrounding();
                if (hNum == around[0] || hNum == around[1] || hNum == around[2] ||
                    hNum == around[3] || hNum == around[4] || hNum == around[5])
                {
                    if (t.getPlayerAble() == null)
                        t.setPlayerAble(player.getBase());
                }
            } 
        }

        #endregion

        private void initStacks()
        { 
            foreach(int num in that._stacks.Keys)
                foreach (KNT_ServiceReference.Thing t in that._stacks[num])
                {
                    if (stacksCpy.ContainsKey(num))
                        stacksCpy[num].Add(new Thing(t));
                    else
                    {
                        stacksCpy.Add(num, new List<Thing>());
                        stacksCpy[num].Add(new Thing(t));
                    }
                }
        }

        Dictionary<int, List<Thing>> stacksCpy;

        KNT_ServiceReference.Tile that;
    }
}
