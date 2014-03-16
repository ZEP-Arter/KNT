using KNT_Service.Networkable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service.Wrapper
{
    [DataContract]
    public class Thing : IThing
    {
        public Thing(string type, string name)
        {
            _type = type;
            _name = name;

            if (that == null)
                that = new GameLogic.Things.Thing();

            Synchronize();
        }

        public Thing(GameLogic.Things.Thing me)
        {
            that = me;

            _type = that.getType();
            _name = that.getName();
            _hexType = that.getHexType();
            _combatValue = that.combatScore();
            _inBank = that.isInBank();
            _onRack = that.isOnRack();
            _isOwned = that.getIsOwned();
            _id = that.getID();
            _goldValue = that.getGoldValue();

            Synchronize();
        }

        public string getType()
        { return _type; }

        public string getName()
        { return _name; }

        public string getHexType()
        { return _hexType; }

        public int getCombatValue()
        { return _combatValue; }

        public bool isInBank()
        { return _inBank; }

        public void setInBank(bool b)
        { _inBank = b; }

        public bool isOnRack()
        { return _onRack; }

        public void setOnRack(bool r)
        { _onRack = r; }

        public bool owned()
        { return _isOwned; }

        public void setIsOwned(bool o)
        { _isOwned = o; }

        public int getID()
        { return _id; }

        public int getGoldValue()
        { return _goldValue; }

        public GameLogic.Things.Thing getBase()
        { return that; }

        public void Sync()
        { Synchronize(); }

        private void Synchronize()
        {
            that.setInBank(_inBank);
            that.setOnRack(_onRack);
            that.setIsOwned(_isOwned);
        }

        [DataMember]
        private string _type;

        [DataMember]
        private string _name;

        [DataMember]
        private string _hexType;

        [DataMember]
        private int _combatValue;

        [DataMember]
        private bool _inBank;

        [DataMember]
        private bool _onRack;

        [DataMember]
        private bool _isOwned;

        [DataMember]
        private int _id;

        [DataMember]
        private int _goldValue;

        private GameLogic.Things.Thing that;
    }
}