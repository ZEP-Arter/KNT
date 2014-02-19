using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace KNT_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class KNTNet : IKNTNet
    {
        public KNTNet()
        {
            game = new Game();
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Player addPlayer(string name)
        {
            Player player = null;

            foreach (Player p in game.getPlayers())
            {
                if (p.getName().Contains("Player"))
                {
                    p.setName(name);
                    game.getPlayers()[game.getPlayers().IndexOf(p)] = p;
                    player = p;
                    break;
                }
            }

            return player;
        }

        public Phase getCurrentPhase()
        {
            return null;
        }

        public GameBoard CreateGame()
        {
            return game.getGame();
        }

        public List<Player> getPlayers()
        {
            return game.getPlayers();
        }

        public Game game;
    }
}
