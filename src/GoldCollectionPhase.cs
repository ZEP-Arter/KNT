using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class GoldCollectionPhase : Phase
    {
        public GoldCollectionPhase(List<Player> players)
            : base("GoldCollection")
        {
            _players = players;
            gold = 0;
            collectGold();
        }

        public void collectGold()
        {
            this.beginPhase();

            foreach (Player p in _players)
            {
                determineGold(p);
                givePlayerGold(p);
                // need something to determine end turn here
            }

            this.endPhase();
        }

        private void determineGold(Player player)
        {
            //1 for every owed land hex
            addGold(player.getNumberOfOwnedTiles());
            //as many gold as the combat value of each fort

            foreach (Thing t in player.getAllForts())
            {
                addGold(t.combatScore());
            }
            //as many gold as printed value of each special income counter ON THE BOARD

            foreach (Thing t in player.getAllSpecialIncomeCounters())
            {
                addGold(t.getGoldValue());
            }

            //1 one gold per special charater
            addGold(player.getNumberOfSpecialCharaters());
        }

        private void givePlayerGold(Player player)
        {
            player.givePlayerGold(gold);
            gold = 0;
        }

        private void addGold(int amount)
        {
            gold += amount;
        }

        private List<Player> _players;

        private int gold
        {
            set
            {
                gold = value;
            }
            get
            {
                return gold;
            }
        }
    }
}
