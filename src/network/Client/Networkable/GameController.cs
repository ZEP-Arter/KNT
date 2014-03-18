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

        public static void CreateGame(List<KNT_ServiceReference.Player> _players, 
                                      KNT_ServiceReference.Board _board,
                                      List<KNT_ServiceReference.Thing> _cup,
                                      Dictionary<string, List<KNT_ServiceReference.Thing>> _bank)
        {
            gc = new GameController();

            foreach (KNT_ServiceReference.Player p in _players)
                players.Add(new Player(p));

            board = new Board(_board);

            foreach (KNT_ServiceReference.Thing t in _cup)
                cup.Add(new Thing(t));
            
            foreach(string type in _bank.Keys)
                foreach (KNT_ServiceReference.Thing t in _bank[type])
                {
                    if (bank.ContainsKey(type))
                        bank[type].Add(new Thing(t));
                    else
                    {
                        bank.Add(type, new List<Thing>());
                        bank[type].Add(new Thing(t));
                    }
                }
        }

        public Board getMap()
        { return board; }

        public Player getPlayer(KNT_ServiceReference.Player player)
        {
            foreach (Player p in players)
            {
                if (player._name == p.getName())
                    return p;
            }

            return null;
        }

        public Thing getRandomThingFromCup()
        {
            if (cup.Count == 0)
                return null;

            Random r = new Random();

            Thing t = cup[r.Next(cup.Count)];

            removeThingFromCup(t);

            return t;
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

            cup = new List<Thing>();

            bank = new Dictionary<string, List<Thing>>();

        }

        private void removeThingFromCup(Thing t)
        { cup.Remove(t); }

        private static GameController               gc;

        static List<Player>                         players;

        static List<Thing>                          cup;

        static Dictionary<string, List<Thing>>      bank;

        static Board                                board;
    }
}
