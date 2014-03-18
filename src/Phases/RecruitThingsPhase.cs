using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Managers;
using GameLogic.Things;

namespace GameLogic.Phases
{
    public class RecruitThingsPhase : Phase
    {
        public RecruitThingsPhase() :
            base("Recruit Things")
        {
            tradins = new List<Thing>();
            doneFree = false;
            donePaid = false;
            doneTrades = false;
        }

        public override void playPhase(KNT_Client.Networkable.Player player)
        {
            _player = player;
            if (currentState != State.IN_PROGRESS)
                beginPhase();

            numFreeRecruits = (_player.getNumberOfOwnedTiles() % 2) != 0 ? (_player.getNumberOfOwnedTiles() / 2) + 1 : (_player.getNumberOfOwnedTiles() / 2);

        }

        public KNT_Client.Networkable.Thing recruitThings()
        {
            if (!doneFree)
                return free();
            else if (!donePaid)
                return paid();

            return null;
        }

        private void displayTradeIns(KNT_Client.Networkable.Player player)
        {
            // if the player decides to trade in things, the must be displayed at the begning of the turn and traded in at the end
            //add things to the the tradins list
        }

        private KNT_Client.Networkable.Thing free()
        {
            KNT_Client.Networkable.Thing t = null;

            if (numFreeRecruits > 5)
                numFreeRecruits = 5;

            //play imidiatly or rack it
            if (numFreeRecruits != 0)
            {
                t = KNT_Client.Networkable.GameController.Game.getRandomThingFromCup();
                --numFreeRecruits;
            }
            
            if(numFreeRecruits == 0)
                doneFree = true;

            return t;
        }

        private KNT_Client.Networkable.Thing paid()
        {
            KNT_Client.Networkable.Thing t = null;

            if (_player.getGold() >= 5)
            {
                //prompt to buy a recruit
                //if no break;
                //if yes deduct 5 gold from player gold and increment total
                //play imidiatly or rack it
                t = KNT_Client.Networkable.GameController.Game.getRandomThingFromCup();
                _player.reciveIncome(-5);
            }
            else
                donePaid = true;

            return t;
        }

        private void trades()
        {
            int numTradins = tradins.Count / 2;

            while (numTradins >= 0)
            {
                //play imidiatly or rack it
                KNT_Client.Networkable.Thing t = KNT_Client.Networkable.GameController.Game.getRandomThingFromCup();
                _player.AddThingToRack(t.getID(), t);
                --numTradins;
            }
        }

        public bool canBeDone()
        {
            return doneFree;
        }

        private List<Thing> tradins;
        private bool doneFree,
                     donePaid,
                     doneTrades;
        int numFreeRecruits;// = (player.getNumberOfOwnedTiles() % 2) != 0 ? (player.getNumberOfOwnedTiles() / 2) + 1 : (player.getNumberOfOwnedTiles() / 2);
    }
}
