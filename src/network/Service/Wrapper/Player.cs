using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameLogic;
using System.Runtime.Serialization;
using System.Drawing;
using System.ServiceModel;
using KNT_Service.Networkable;

namespace KNT_Service.Wrapper
{
    [DataContract]
    public class Player : IPlayer
    {
        public Player(string name, int yPos, int pNumber)
        {
            _name = name;
            _turn = 0;
            _goldY = yPos;
            _gold = 10;
            _myMarkers = new Dictionary<int, bool>();
            _diceRoll = -1;
            _ownedTiles = new List<Tile>();
            _thingsInPlay = new List<Thing>();
            _rack = new Dictionary<int, Thing>();
            _holdingMarker = false;
            _inPhase = false;
            _playerNumber = pNumber;

            if (that == null)
                that = new GameLogic.Player(_name, _goldY, _playerNumber);

            Synchronize();
        }

        public Player(GameLogic.Player me)
        {
            that = me;

            _name = that.getName();
            _turn = 0;
            _goldY = that.getGoldYPos();
            _gold = that.getPlayerGold();
            _myMarkers = that.getMyMarkers();
            _diceRoll = that.getDiceRoll();
            _ownedTiles = new List<Tile>();

            foreach (GameLogic.Tile t in that.getOwnedTiles())
                _ownedTiles.Add(new Tile(t));

            _thingsInPlay = new List<Thing>();

            foreach (GameLogic.Things.Thing t in that.getThingsInPlay())
                _thingsInPlay.Add(new Thing(t));

            _rack = new Dictionary<int, Thing>();

            foreach (int i in that.getRack().Keys)
                _rack.Add(i, new Thing(that.getRack()[i]));

            _holdingMarker = that.handsFull();
            _inPhase = that.getInPhase();
            _playerNumber = that.getPlayerNumber();

            Synchronize();
        }

        public string getName()
        { return _name; }

        public void setName(string n)
        { _name = n; }

        public int getTurn()
        { return _turn; }

        public void setTurn(int t)
        { _turn = t; }

        public int getDiceroll()
        { return _diceRoll; }

        public void setDiceroll(int roll)
        { _diceRoll = roll; }

        public List<Thing> getThingsInPlay()
        { return _thingsInPlay; }

        public Dictionary<int, Thing> getRack()
        { return _rack; }

        public List<Tile> getOwnedTiles()
        { return _ownedTiles; }

        public int getGold()
        { return _gold; }

        public void setGoldValue(int value)
        { _gold = value; }

        public Point getDrawingPosition()
        { return new Point(_goldX, _goldY); }

        public void setDrawingYPosition(int y)
        { _goldY = y; }

        public Dictionary<int, bool> getMyMarkers()
        { return _myMarkers; }

        public bool containsMarkerID(int id)
        { return _myMarkers.ContainsKey(id); }

        public void addMarkerID(int id)
        { _myMarkers.Add(id, false); }

        public int getCurrentMarkerID()
        { return _currentMarkerID; }

        public bool isHoldingMarker()
        { return _holdingMarker; }

        public void setHandsFull()
        { _holdingMarker = _holdingMarker ? false : true; }

        public bool isInPhase()
        { return _inPhase; }

        public int getPlayerNumber()
        { return _playerNumber; }

        public GameLogic.Player getBase()
        { return that; }

        public void Sync()
        { Synchronize(); }

        private void Synchronize()
        {
            that.setName(_name);
            that.setTurn(_turn);
            that.setDiceRoll(_diceRoll);
            //some how have to do things in play
            foreach (Thing t in _thingsInPlay)
                t.Sync();
            //  and rack
            foreach (Thing t in _rack.Values)
                t.Sync();
            //  and ownedTiles
            foreach (Tile t in _ownedTiles)
                t.Sync();
            //  and myMarkers
            that.syncMyMarkers(_myMarkers);
            that.setGold(_gold);
            that.setCurrentMarker(_currentMarkerID);
            that.setHandsFull(_holdingMarker);
            that.setInPhase(_inPhase);
        }

        [DataMember]
        private string _name;

        [DataMember]
        private int _turn;

        [DataMember]
        private int _diceRoll;

        [DataMember]
        private List<Thing> _thingsInPlay;

        [DataMember]
        private Dictionary<int, Thing> _rack;

        [DataMember]
        private List<Tile> _ownedTiles;

        [DataMember]
        private int _gold;

        [DataMember]
        private const int _goldX = 660;

        [DataMember]
        private int _goldY;

        [DataMember]
        private Dictionary<int, bool> _myMarkers;

        [DataMember]
        private int _currentMarkerID;

        [DataMember]
        private bool _holdingMarker;

        [DataMember]
        private bool _inPhase;

        [DataMember]
        private int _playerNumber;

        private GameLogic.Player that;
    }
}