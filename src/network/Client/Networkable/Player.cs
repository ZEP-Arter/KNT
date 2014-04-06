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

            myMarkers = new Dictionary<int, bool>();

            ownedTilesCpy = new List<Tile>();

            initOwnedTiles();

            thingsInPlayCpy = new List<Thing>();

            initThingsInPlay();

            rackCpy = new Dictionary<int, Thing>();

            initRack();
        }

        #region Public_Methods

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

        public void reciveIncome(int income)
        { that._gold += income; }

        public Point getDrawingPosition()
        { return new Point(660, that._goldY); }

        public void setDrawingYPosition(int y)
        { that._goldY = y; }

        public Dictionary<int, bool> getMyMarkers()
        { return myMarkers; }

        public bool containsMarkerID(int id)
        { return myMarkers.ContainsKey(id); }

        public void addMarkerID(int id)
        { myMarkers.Add(id, false); }

        public int getCurrentMarkerID()
        { return that._currentMarkerID; }

        public void setCurrentMarkerID(int id)
        { that._currentMarkerID = id; }

        public bool isHoldingMarker()
        { return that._holdingMarker; }

        public void setHandsFull()
        { that._holdingMarker = that._holdingMarker ? false : true; }

        public bool isInPhase()
        { return that._inPhase; }

        public void donePhase()
        { that._inPhase = false; }// GameLogic.Phases.Phase.State.END; }

        public void startPhase()
        { that._inPhase = true; }

        public bool placedAllMarkers()
        { return !myMarkers.ContainsValue(false); }

        public int getPlayerNumber()
        { return that._playerNumber; }

        public List<Thing> getThingsInPlay()
        { return thingsInPlayCpy; }

        public Dictionary<int, Thing> getRack()
        { return rackCpy; }

        public List<Tile> getOwnedTiles()
        { return ownedTilesCpy; }

        public List<Thing> getAllForts()
        {
            List<Thing> forts = new List<Thing>();

            foreach (Thing t in thingsInPlayCpy)
            {
                if (t.GetType().Equals("Fort"))
                    forts.Add(t);
            }

            return forts;
        }

        public void AddThingToRack(int id , Thing t)
        {
            if (!rackCpy.ContainsKey(id))
                rackCpy.Add(id, t);
        }

        public void playThing(int id)
        {
            thingsInPlayCpy.Add(rackCpy[id]);
            removeFromRack(id);
        }

        public void removeFromRack(int id)
        { rackCpy.Remove(id); }

        public bool isRackFull()
        { return !(rackCpy.Count == 0); }

        public int numberOfRackTiles()
        { return rackCpy.Count; }

        public int getNumberOfOwnedTiles()
        { return ownedTilesCpy.Count; }

        public KNT_ServiceReference.Player getBase()
        { return that; }

        public void addOwnedTile(Tile t)
        {
            ownedTilesCpy.Add(t);
            //that._ownedTiles.Add(t.getBase());
        }

        public void placeMarker(int id)
        { myMarkers[id] = true; }


        public void reSync(KNT_ServiceReference.Player p)
        {
            that = p;

            // run recursive sync on each list
            //ownedTilesCpy = new List<Tile>();

            //initOwnedTiles();

            //thingsInPlayCpy = new List<Thing>();

            //initThingsInPlay();

            //rackCpy = new Dictionary<int, Thing>();

            //initRack();
        }

        #endregion

        #region Private_Methods

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

        #endregion

        List<Tile> ownedTilesCpy;

        List<Thing> thingsInPlayCpy;

        Dictionary<int, Thing> rackCpy;

        Dictionary<int, bool> myMarkers;

        KNT_ServiceReference.Player that;
    }
}
