using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Managers;
using GameLogic.Things;
using KNT_Client.Networkable;

namespace GameLogic.Phases
{
    public class GoldCollectionPhase : Phase
    {
        public GoldCollectionPhase()
            : base("Gold Collection")
        {
            gold = 0;
        }

        public override void playPhase(KNT_Client.Networkable.Player player)
        {
            _player = player;

            if (currentState != State.IN_PROGRESS)
                beginPhase();


            // we need some window to display things here
            collectGold();
        }

        public void collectGold()
        {
            determineGold();
            givePlayerGold();
            endPhase();
        }

        private void determineGold()
        {
            //1 for every owed land hex
            foreach (KNT_Client.Networkable.Tile t in GameController.Game.getMap().getHexList())
            {
                if (t.getPlayer() != null)
                {
                    if (t.getPlayer().Equals(_player))
                        addGold(1);
                }
            }
            //as many gold as the combat value of each fort

            foreach (KNT_Client.Networkable.Thing t in _player.getAllForts())
            {
                addGold(t.getCombatValue());
            }
            //as many gold as printed value of each special income counter ON THE BOARD

            /*foreach (Thing t in player.getAllSpecialIncomeCounters())
            {
                addGold(t.getGoldValue());
            }*/

            //1 one gold per special charater
            //addGold(player.getNumberOfSpecialCharaters());
        }

        private void givePlayerGold()
        {
            _player.reciveIncome(gold);
            gold = 0;
            _player.donePhase();
        }

        private void addGold(int amount)
        {
            gold += amount;
        }

        private int gold;
    }
}
