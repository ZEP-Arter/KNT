using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KNT_Service.Networkable
{
    [ServiceContract]
    public interface ITile
    {
        [OperationContract]
        bool getCFlag();

        [OperationContract]
        Wrapper.Player getPlayer();

        [OperationContract]
        Wrapper.Player getPlayerAble();

        [OperationContract]
        bool getPlayerControlBool();

        [OperationContract]
        int[] getSurrounding();

        [OperationContract]
        int getHexNum();

        [OperationContract]
        string getHexType();

        [OperationContract]
        void resetMovementLogic();

        [OperationContract]
        bool isRough();

        [OperationContract]
        bool getFaceUp();

        [OperationContract]
        bool getStart();

        [OperationContract]
        void flipTile();

        [OperationContract]
        int getFortLevel();

        [OperationContract]
        Dictionary<int, List<Wrapper.Thing>> getStacks();

        [OperationContract]
        bool isTraversed();
    }
}