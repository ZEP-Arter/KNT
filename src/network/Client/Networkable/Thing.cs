using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNT_Client.Networkable
{
    public class Thing
    {
        public Thing(KNT_ServiceReference.Thing t)
        { that = t; }

        public string getType()
        { return that._type; }

        public string getName()
        { return that._name; }

        public string getHexType()
        { return that._hexType; }

        public int getCombatValue()
        { return that._combatValue; }

        public bool isInBank()
        { return that._inBank; }

        public void setInBank(bool b)
        { that._inBank = b; }

        public bool isOnRack()
        { return that._onRack; }

        public void setOnRack(bool r)
        { that._onRack = r; }

        public bool owned()
        { return that._isOwned; }

        public void setIsOwned(bool o)
        { that._isOwned = o; }

        public int getID()
        { return that._id; }

        public int getGoldValue()
        { return that._goldValue; }

        KNT_ServiceReference.Thing that;
    }
}
