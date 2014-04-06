using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using KNT_Service.Wrapper;

namespace KNT_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IKNTNet
    {
        [OperationContract]
        Player addPlayer(Player player, string name);

        [OperationContract]
        List<Player> getPlayers();

        [OperationContract]
        List<Thing> getCup();

        [OperationContract]
        Dictionary<string, List<Thing>> getBank();

        [OperationContract]
        Player getCurrentPlayer();

        [OperationContract]
        Board getMap();

        [OperationContract]
        Player connect(string player);

        [OperationContract]
        bool doTurn(string state, Player player);

        [OperationContract]
        void updateMe(Player p);

        [OperationContract]
        void updateBoard(Board b);
    }
}
