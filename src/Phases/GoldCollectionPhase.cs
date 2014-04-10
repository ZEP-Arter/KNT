using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Phases
{
    public class GoldCollectionPhase : Phase
    {
        public GoldCollectionPhase()
            : base("Gold Collection")
        {
            gold = 0;
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;

            if (currentState != State.IN_PROGRESS)
                beginPhase();

            if (currentPlayer == null)
                currentPlayer = players[0];

            collectGold();
        }

        public void collectGold()
        {
            //if (currentPlayer.getInPhase())
            //    changePlayer();
            for (int i = 0; i < _players.Capacity; i++)
            {

                determineGold(currentPlayer);
                givePlayerGold(currentPlayer);
                changePlayer();
            }

            if( allDone() )
                endPhase();
        }

        private void determineGold(Player player)
        {
            //1 for every owed land hex
            foreach (Tile t in player.getOwnedTiles())
            {
                addGold(1);
            }
            //as many gold as the combat value of each fort
            foreach (Tile t in player.getOwnedTiles())
            {
                addGold(t.getFort());
            }
            //as many gold as printed value of each special income counter ON THE BOARD

            /*foreach (Thing t in player.getAllSpecialIncomeCounters())
            {
                addGold(t.getGoldValue());
            }*/

            //1 one gold per special charater
            //addGold(player.getNumberOfSpecialCharaters());
        }

        private void givePlayerGold(Player player)
        {
            player.givePlayerGold(gold);
            gold = 0;
            player.donePhase();
        }

        private void addGold(int amount)
        {
            gold += amount;
        }

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private int gold;
    }
}
