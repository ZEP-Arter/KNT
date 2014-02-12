using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
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

        public void recruitThings()
        {
            if (currentPlayer.getInPhase())
            {
                changePlayer();
                numFreeRecruits = (currentPlayer.getNumberOfOwnedTiles() % 2) != 0 ? (currentPlayer.getNumberOfOwnedTiles() / 2) + 1 : (currentPlayer.getNumberOfOwnedTiles() / 2);
                doneFree = false;
            }
            else if (!doneFree)
                free(currentPlayer);
            else if (!donePaid)
                paid(currentPlayer);
            if (allDone())
                endPhase();
        }

        private void displayTradeIns(Player player)
        {
            // if the player decides to trade in things, the must be displayed at the begning of the turn and traded in at the end
            //add things to the the tradins list
        }

        private void free(Player player)
        {
            if (numFreeRecruits > 5)
                numFreeRecruits = 5;

            //play imidiatly or rack it
            if (numFreeRecruits != 0)
            {
                Thing t = GameBoard.Game.getRandomThingFromCup();
                player.AddThingToRack(t.getID(), t);
                --numFreeRecruits;
            }
            
            if(numFreeRecruits == 0)
                doneFree = true;
        }

        private void paid(Player player)
        {
            if (player.getGold() >= 5)
            {
                //prompt to buy a recruit
                //if no break;
                //if yes deduct 5 gold from player gold and increment total
                //play imidiatly or rack it
                Thing t = GameBoard.Game.getRandomThingFromCup();
                player.givePlayerGold(-5);
                player.AddThingToRack(t.getID(), t);
            }
            else
                donePaid = true;
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
