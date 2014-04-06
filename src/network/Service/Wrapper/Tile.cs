using KNT_Service.Networkable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service.Wrapper
{
    [DataContract]
    public class Tile : ITile
    {
        public Tile(int hexNum, int[] around, string hexType)
        {
            _hexNumber = hexNum;
            _nHex = around[0];
            _neHex = around[1];
            _seHex = around[2];
            _sHex = around[3];
            _swHex = around[4];
            _nwHex = around[5];
            _hexType = hexType;
            _stacks.Add(1, new List<Thing>());
            _stacks.Add(2, new List<Thing>());
            _stacks.Add(3, new List<Thing>());
            _stacks.Add(4, new List<Thing>());

            if (hexType == "Swamp" ||
                hexType == "Forest" ||
                hexType == "Mountain" ||
                hexType == "Jungle")
                _rough = true;

            if (that == null)
                that = new GameLogic.Tile(hexNum, around, hexType);

            Synchronize();
        }

        public Tile(int hexNum, int[] around, string hexType, bool startPossible)
        {
            _hexNumber = hexNum;
            _nHex = around[0];
            _neHex = around[1];
            _seHex = around[2];
            _sHex = around[3];
            _swHex = around[4];
            _nwHex = around[5];
            _hexType = hexType;
            _stacks = new Dictionary<int, List<Thing>>();
            _stacks.Add(1, new List<Thing>());
            _stacks.Add(2, new List<Thing>());
            _stacks.Add(3, new List<Thing>());
            _stacks.Add(4, new List<Thing>());

            _startPossible = startPossible;

            if (hexType == "Swamp" ||
                hexType == "Forest" ||
                hexType == "Mountain" ||
                hexType == "Jungle")
                _rough = true;

            if (that == null)
                that = new GameLogic.Tile(hexNum, around, hexType);

            Synchronize();
        }

        public Tile(GameLogic.Tile me)
        {
            hasBeenInit = false;

            that = me;

            _hexNumber = that.getHexNum();
            int[] temp = that.getSurrounding();
            _nHex = temp[0];
            _neHex = temp[1];
            _seHex = temp[2];
            _sHex = temp[3];
            _swHex = temp[4];
            _nwHex = temp[5];
            _hexType = that.getHexType();
            _stacks = new Dictionary<int, List<Thing>>();
            _rough = that.isRough();
            _faceUp = that.getFaceUp();
            _startPossible = that.getStart();
            _fortLevel = that.getFortLevel();
            _combatFlagged = that.getCFlag();
            _playerAbleToStart = null;
            _playerControl = null;
            _playerControlBool = that.getPlayerControlBool();
            _traversed = that.isTraversed();

            Synchronize();

            hasBeenInit = true;
        }
        
        public bool getCFlag() 
        { return _combatFlagged; }

        public Player getPlayer()
        { return _playerControl; }

        public Player getPlayerAble() 
        { return _playerAbleToStart; }

        public bool getPlayerControlBool() 
        { return _playerControlBool; }

        public int[] getSurrounding() 
        { return new int[] { _nHex, _neHex, _seHex, _sHex, _swHex, _nwHex }; }

        public int getHexNum() 
        { return _hexNumber; }

        public string getHexType() 
        { return _hexType; }

        public void resetMovementLogic() 
        { _traversed = false; }

        public bool isRough() 
        { return _rough; }

        public bool getFaceUp() 
        { return _faceUp; }

        public bool getStart() 
        { return _startPossible; }

        public void flipTile() 
        { _faceUp = true; }

        public int getFortLevel() 
        { return _fortLevel; }

        public Dictionary<int, List<Thing>> getStacks() 
        { return _stacks; }

        public bool isTraversed() 
        { return _traversed; }

        public GameLogic.Tile getBase()
        { return that; }

        public void Sync()
        { Synchronize(); }

        public void Sync(Tile t)
        {
            _hexNumber = t.getHexNum();
            int[] temp = t.getSurrounding();
            _nHex = temp[0];
            _neHex = temp[1];
            _seHex = temp[2];
            _sHex = temp[3];
            _swHex = temp[4];
            _nwHex = temp[5];
            _hexType = t.getHexType();
            _stacks = new Dictionary<int, List<Thing>>();
            _rough = t.isRough();
            _faceUp = t.getFaceUp();
            _startPossible = t.getStart();
            _fortLevel = t.getFortLevel();
            _combatFlagged = t.getCFlag();
            _playerAbleToStart = t.getPlayerAble();
            _playerControl = t.getPlayer();
            _playerControlBool = t.getPlayerControlBool();
            _traversed = t.isTraversed();

            Synchronize();
        }

        private void Synchronize()
        {
            that.setPlayerAble(_playerAbleToStart != null ? _playerAbleToStart.getBase() : null);
            that.setCFlag(_combatFlagged);
            that.setPlayerControl(_playerControl != null ? _playerControl.getBase() : null);
            that.setPlayerControlBool(_playerControlBool);

            if (hasBeenInit)
            {
                _playerControl = GameController.Game.getNetPlayer(that.getPlayer());
                _playerAbleToStart = GameController.Game.getNetPlayer(that.getPlayer());
            }
        }

        [DataMember]
        private int _hexNumber;

        [DataMember]
        private int _nHex;

        [DataMember]
        private int _neHex;

        [DataMember]
        private int _seHex;

        [DataMember]
        private int _sHex;

        [DataMember]
        private int _swHex;

        [DataMember]
        private int _nwHex;

        [DataMember]
        private string _hexType;

        [DataMember]
        private bool _faceUp;

        [DataMember]
        private bool _startPossible;

        [DataMember]
        private Dictionary<int, List<Thing>> _stacks;

        [DataMember]
        private List<Thing> _p1Stack;

        [DataMember]
        private List<Thing> _p2Stack;

        [DataMember]
        private List<Thing> _p3Stack;

        [DataMember]
        private List<Thing> _p4Stack;

        [DataMember]
        private int _fortLevel;

        [DataMember]
        private bool _combatFlagged;

        [DataMember]
        private bool _rough;

        [DataMember]
        private bool _playerControlBool;

        [DataMember]
        private Player _playerControl;

        [DataMember]
        private Player _playerAbleToStart;

        [DataMember]
        public bool _traversed;

        public bool hasBeenInit;

        private GameLogic.Tile that;
    }
}