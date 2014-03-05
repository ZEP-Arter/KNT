using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using GameLogic.Managers;

namespace KNT_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class KNTNet : IKNTNet
    {
        public KNTNet()
        {
            SerializerOpBehavior.ImportXSD();
        }

        public Player addPlayer(string name)
        {
            return GameBoard.Game.changePlayerName(name);
        }

        public Phase getCurrentPhase()
        {
            return GameBoard.Game.getCurrentPhase();
        }

        public void setCurrentPhase()
        {
        
        }

        public GameBoard connect(string player)
        {
            Console.WriteLine(String.Format("Recived new connetction from player {0}!", player));
            return GameBoard.Game;
        }

        public List<Player> getPlayers()
        {
            return GameBoard.Game.getPlayers();
        }

        public Player getCurrentPlayer()
        {
            return null;
        }

        public Board getMap()
        {
            return GameBoard.Game.getMap();
        }
    }
}
