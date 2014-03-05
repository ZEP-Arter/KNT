using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameLogic;
using GameLogic.Managers;

namespace KNT_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IKNTNet
    {
        [OperationContract]
        Player addPlayer(string name);

        [OperationContract]
        Phase getCurrentPhase();

        [OperationContract]
        void setCurrentPhase();

        [OperationContract]
        List<Player> getPlayers();

        [OperationContract]
        Player getCurrentPlayer();

        [OperationContract]
        Board getMap();

        [OperationContract]
        GameBoard connect(string player);
    }
}
