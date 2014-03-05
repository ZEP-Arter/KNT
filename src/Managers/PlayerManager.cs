using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace GameLogic.Managers
{
    [DataContract(IsReference = false)]
    public class PlayerManager
    {
        public Player changePlayerName(string name)
        {
            pSemaphore.WaitOne();

            Player toReturn = null;

            foreach (Player p in players)
                if (p.getName().Contains("Player"))
                {
                    p.setName(name);
                    toReturn = p;
                }

            pSemaphore.Release();

            return toReturn;
        }

        public void addPlayer(string name)
        {
            int display = 0;

            pSemaphore.WaitOne();

            switch (players.Count)
            {
                case 0:
                    display = 110;
                    break;
                case 1:
                    display = 245;
                    break;
                case 2:
                    display = 380;
                    break;
                case 3:
                    display = 515;
                    break;
            }

            players.Add(new Player(name, display, players.Count + 1));

            pSemaphore.Release();
        }

        public bool setPlayerOrder()
        {
            SortedDictionary<int, Player> order = new SortedDictionary<int, Player>();

            pSemaphore.WaitOne();

            foreach (Player p in players)
            {
                int roll = p.getDiceRoll();
                Console.WriteLine(String.Format("Player {0} rolled {1}.", p.getName(), roll));

                if (!order.ContainsKey(roll))
                    order.Add(roll, p);

                else
                {
                    Console.WriteLine("There is a duplicate roll, rolling again . . .");
                    return false;
                }
            }

            players = order.Values.ToList<Player>();
            players.Reverse();

            pSemaphore.Release();

            return true;
        }

        public List<Player> getPlayers()
        {
            return players;
        }

        public Player getPlayer(string name)
        {
            pSemaphore.WaitOne();

            foreach (Player p in players)
            {
                if (p.getName().Equals(name))
                {
                    pSemaphore.Release();
                    return p;
                }
            }

            pSemaphore.Release();

            return null;
        }

        private PlayerManager()
        {
            players = new List<Player>(4);
        }

        [DataMember]
        private List<Player> players;

        //private Player currentPlayer;

        [DataMember]
        private static Semaphore pSemaphore = new Semaphore(1, 1);

        [DataMember]
        private static PlayerManager pManager;

        [DataMember]
        public static PlayerManager PManager
        {
            get
            {
                pSemaphore.WaitOne();

                if (pManager == null)
                    pManager = new PlayerManager();

                pSemaphore.Release();

                return pManager;
            }
        }
    }
}
