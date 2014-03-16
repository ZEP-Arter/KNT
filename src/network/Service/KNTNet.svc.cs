using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using KNT_Service.Wrapper;

namespace KNT_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class KNTNet : IKNTNet
    {
        public Player addPlayer(Player player, string name)
        {
            return GameController.Game.changePlayerName(player, name);
        }

        public Player connect(string player)
        {
            Console.WriteLine(String.Format("Recived new connetction from player {0}!", player));
            return GameController.Game.newConnection(player);
        }

        public List<Player> getPlayers()
        {
            return GameController.Game.getPlayers();
        }

        public List<Thing> getCup()
        {
            return GameController.Game.getCup();
        }

        public Dictionary<string, List<Thing>> getBank()
        {
            return GameController.Game.getBank();
        }

        public Player getCurrentPlayer()
        {
            return null;
        }

        public Board getMap()
        {
            return GameController.Game.getMap();
        }
    }
}
