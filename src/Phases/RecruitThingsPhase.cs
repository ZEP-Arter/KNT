using GameLogic.Managers;
using GameLogic.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if (currentState != State.IN_PROGRESS)
                beginPhase();

            if (currentPlayer == null)
            {
                currentPlayer = players[0];
                numFreeRecruits = (currentPlayer.getNumberOfOwnedTiles() % 2) != 0 ? (currentPlayer.getNumberOfOwnedTiles() / 2) + 1 : (currentPlayer.getNumberOfOwnedTiles() / 2);
            }

        }

        public Thing recruitThings()
        {
            if (currentPlayer.getInPhase())
            {
                changePlayer();
                numFreeRecruits = (currentPlayer.getNumberOfOwnedTiles() % 2) != 0 ? (currentPlayer.getNumberOfOwnedTiles() / 2) + 1 : (currentPlayer.getNumberOfOwnedTiles() / 2);
                doneFree = false;
            }
            else if (!doneFree)
                return free(currentPlayer);
            else if (!donePaid)
                return paid(currentPlayer);
            if (allDone())
                endPhase();

            return null;
        }

        private void displayTradeIns(Player player)
        {
            // if the player decides to trade in things, the must be displayed at the begning of the turn and traded in at the end
            //add things to the the tradins list
        }

        private Thing free(Player player)
        {
            Thing t = null;

            if (numFreeRecruits > 5)
                numFreeRecruits = 5;

            //play imidiatly or rack it
            if (numFreeRecruits != 0)
            {
                t = GameBoard.Game.getRandomThingFromCup();
                --numFreeRecruits;
            }
            
            if(numFreeRecruits == 0)
                doneFree = true;

            return t;
        }

        private Thing paid(Player player)
        {
            Thing t = null;

            if (player.getGold() >= 5)
            {
                //prompt to buy a recruit
                //if no break;
                //if yes deduct 5 gold from player gold and increment total
                //play imidiatly or rack it
                t = GameBoard.Game.getRandomThingFromCup();
                player.givePlayerGold(-5);
            }
            else
                donePaid = true;

            return t;
        }

        private void trades(Player player)
        {
            int numTradins = tradins.Count / 2;

            while (numTradins >= 0)
            {
                //play imidiatly or rack it
                Thing t = GameBoard.Game.getRandomThingFromCup();
                player.AddThingToRack(t.getID(), t);
                --numTradins;
            }
        }

        public bool canBeDone()
        {
            return doneFree;
        }

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private List<Thing> tradins;
        private bool doneFree,
                     donePaid,
                     doneTrades;
        int numFreeRecruits;// = (player.getNumberOfOwnedTiles() % 2) != 0 ? (player.getNumberOfOwnedTiles() / 2) + 1 : (player.getNumberOfOwnedTiles() / 2);
    }
}
