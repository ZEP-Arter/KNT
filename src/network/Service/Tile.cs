using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service
{
    [DataContract]
    public class Tile
    {

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
        public Dictionary<int, List<GameLogic.Thing>> _stacks = new Dictionary<int, List<GameLogic.Thing>>();

        //Level is 0 if there is no Fort
        [DataMember]
        private int _fortLevel = 0;

        [DataMember]
        private bool _combatFlagged = false;
        [DataMember]
        private bool _rough = false;

        [DataMember]
        private bool _playerControlBool = false;

        [DataMember]
        private GameLogic.Player _playerControl = null;
        [DataMember]
        private GameLogic.Player _playerAbleToStart = null;

        //Movement logic variable
        [DataMember]
        public bool _traversed = false;

        GameLogic.Tile _tile;

        Tile(GameLogic.Tile t)
        {
            _tile = t;
            init();
        }

        private void init()
        {
            _hexNumber = _tile.getHexNum();
            _nHex = _tile.getSurrounding()[0];
            _neHex = _tile.getSurrounding()[1];
            _seHex = _tile.getSurrounding()[2];
            _sHex = _tile.getSurrounding()[3];
            _swHex = _tile.getSurrounding()[4];
            _nwHex = _tile.getSurrounding()[5];
            _hexType = _tile.getHexType();
            _faceUp = _tile.getFaceUp();
            _startPossible = _tile.getStart();
            _stacks = _tile.stacks;
            _fortLevel = _tile.getFortLevel();
            _combatFlagged = _tile.getCFlag();
            _rough = _tile.isRough();
            _playerControlBool = _tile.getPlayerControlBool();
            _playerControl = _tile.getPlayer();
            _playerAbleToStart = _tile.getPlayerAble();
            _traversed = _tile.traversed;
        }

        public void setStacks(Dictionary<int, List<GameLogic.Thing>> d)
        {
            _stacks = d;
            _tile.stacks = _stacks;
        }

        public void setCFlag(bool b)
        {
            _combatFlagged = b;
            _tile.setCFlag(_combatFlagged);
        }

        public void setPlayerControl(GameLogic.Player p)
        {
            _playerControl = p;
            _tile.setPlayerControl(_playerControl);
        }

        public void setPlayerControlBool(bool b)
        {
            _playerControlBool = b;
            _tile.setPlayerControlBool(_playerControlBool);
        }

        public void setTraversed(bool b)
        {
            _traversed = b;
            _tile.traversed = b;
        }
    }
}