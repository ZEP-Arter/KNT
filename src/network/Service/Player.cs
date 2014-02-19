using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service
{
    [DataContract]
    public class Player
    {
        public Player(GameLogic.Player p)
        {
            _me = p;
            init();
        }

        public string getName()
        {
            return _name;
        }

        public void setName(string name)
        {
            _name = name;
            _me.setName(name);
        }

        [DataMember]
        string _name;

        public int getDiceroll()
        {
            return _diceRoll;
        }

        public void setDiceroll(int roll)
        {
            _diceRoll = roll;
            _me.setDiceRoll(roll);
        }

        [DataMember]
        int _diceRoll;

        [DataMember]
        int _gold;

        [DataMember]
        int _currentMarkerID;

        [DataMember]
        bool _holdingMarker;

        [DataMember]
        bool _inPhase;

        [DataMember]
        int _playerNumber;

        private void init()
        {
            _name = _me.getName();

            _diceRoll = _me.getDiceRoll();

            _gold = _me.getGold();

            _holdingMarker = _me.handsFull();

            _inPhase = _me.getInPhase();

            _playerNumber = _me.getPlayerNumber();
        }

        GameLogic.Player _me;

    }
}