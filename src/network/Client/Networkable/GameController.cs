using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNT_Client.Networkable
{
    public class GameController
    {
        public List<Player> getPlayers()
        { return players; }

        public static void CreateGame(List<KNT_ServiceReference.Player> _players)
        {
            gc = new GameController();

            foreach (KNT_ServiceReference.Player p in _players)
                players.Add(new Player(p));
        }

        public Player getPlayer(KNT_ServiceReference.Player player)
        {
            foreach (Player p in players)
            {
                if (player._name == p.getName())
                    return p;
            }

            return null;
        }

        public static GameController Game
        {
            get
            {
                return gc;
            }
        }

        private GameController()
        {
            players = new List<Player>(4);
        }

        private static GameController gc;

        static List<Player> players;
    }
}
