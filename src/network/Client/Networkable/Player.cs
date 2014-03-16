using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT_Client.KNT_ServiceReference;
using System.Drawing;

namespace KNT_Client.Networkable
{
    public class Player
    {
        public Player(KNT_ServiceReference.Player p)
        { 
            that = p;

            ownedTilesCpy = new List<Tile>();

            initOwnedTiles();

            thingsInPlayCpy = new List<Thing>();

            initThingsInPlay();

            rackCpy = new Dictionary<int, Thing>();

            initRack();
        }

        public string getName()
        { return that._name; }

        public void setName(string n)
        { that._name = n; }

        public int getTurn()
        { return that._turn; }

        public void setTurn(int t)
        { that._turn = t; }

        public int getDiceroll()
        { return that._diceRoll; }

        public void setDiceroll(int roll)
        { that._diceRoll = roll; }

        public int getGold()
        { return that._gold; }

        public void setGoldValue(int value)
        { that._gold = value; }

        public Point getDrawingPosition()
        { return new Point(660, that._goldY); }

        public void setDrawingYPosition(int y)
        { that._goldY = y; }

        public Dictionary<int, bool> getMyMarkers()
        { return that._myMarkers; }

        public bool containsMarkerID(int id)
        { return that._myMarkers.ContainsKey(id); }

        public void addMarkerID(int id)
        { that._myMarkers.Add(id, false); }

        public int getCurrentMarkerID()
        { return that._currentMarkerID; }

        public bool isHoldingMarker()
        { return that._holdingMarker; }

        public void setHandsFull()
        { that._holdingMarker = that._holdingMarker ? false : true; }

        public bool isInPhase()
        { return that._inPhase; }

        public int getPlayerNumber()
        { return that._playerNumber; }

        public List<Thing> getThingsInPlay()
        { return thingsInPlayCpy; }

        public Dictionary<int, Thing> getRack()
        { return rackCpy; }

        public List<Tile> getOwnedTiles()
        { return ownedTilesCpy; }

        private void initThingsInPlay()
        {
            foreach (KNT_ServiceReference.Thing t in that._thingsInPlay)
                thingsInPlayCpy.Add(new Thing(t));
        }

        private void initRack()
        {
            foreach (int i in that._rack.Keys)
                foreach (KNT_ServiceReference.Thing t in that._rack.Values)
                {
                    if (rackCpy.ContainsKey(i))
                        rackCpy[i] = new Thing(t);
                    else
                        rackCpy.Add(i, new Thing(t));
                }
        }

        private void initOwnedTiles()
        {
            foreach (KNT_ServiceReference.Tile t in that._ownedTiles)
                ownedTilesCpy.Add(new Tile(t));
        }

        List<Tile> ownedTilesCpy;

        List<Thing> thingsInPlayCpy;

        Dictionary<int, Thing> rackCpy;

        KNT_ServiceReference.Player that;

    }
}
