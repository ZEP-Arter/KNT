using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class GoldCollectionPhase : Phase
    {
        public GoldCollectionPhase(Player player)
            : base("GoldCollection")
        {
            _player = player;
            gold = 0;
        }

        private void determineGold()
        {
            //1 for every owed land hex
            addGold(_player.getNumberOfOwnedTiles());
            //as many gold as the combat value of each fort

            foreach (Thing t in _player.getAllForts())
            {
                addGold(t.combatScore());
            }
            //as many gold as printed value of each special income counter ON THE BOARD

            foreach (Thing t in _player.getAllSpecialIncomeCounters())
            {
                addGold(t.getGoldValue());
            }

            //1 one gold per special charater
            addGold(_player.getNumberOfSpecialCharaters());
        }

        private void addGold(int amount)
        {
            gold += amount;
        }

        private Player _player;

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
