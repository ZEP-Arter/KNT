using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KNT_Service.Networkable
{
    [ServiceContract]
    public interface IThing
    {
        [OperationContract]
        string getType();

        [OperationContract]
        string getName();

        [OperationContract]
        string getHexType();

        [OperationContract]
        int getCombatValue();

        [OperationContract]
        bool isInBank();

        [OperationContract]
        void setInBank(bool b);

        [OperationContract]
        bool isOnRack();

        [OperationContract]
        void setOnRack(bool r);

        [OperationContract]
        bool owned();

        [OperationContract]
        void setIsOwned(bool o);

        [OperationContract]
        int getID();

        [OperationContract]
        int getGoldValue();
    }
}