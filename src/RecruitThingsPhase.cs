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
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if (currentState != State.IN_PROGRESS)
                beginPhase();

            if (currentPlayer == null)
                currentPlayer = players[0];
            recruitThings();
        }

        private void recruitThings()
        {
            this.beginPhase();

            foreach (Player p in _players)
            {
                //if skip break;
                //prompt to take trad ins'?
                //displayTradeIns(p);
                //prompt to take free things?
                //if yes free(p);
                //prompt to take paid things?
                //if yes paid(p);
                //if yes trades(p);
                //need something to determine end turn here
            }
            if (false)
                this.endPhase();
        }

        private void displayTradeIns(Player player)
        {
            // if the player decides to trade in things, the must be displayed at the begning of the turn and traded in at the end
            //add things to the the tradins list
        }

        private void free(Player player)
        {
            int numFreeRecruits = (player.getNumberOfOwnedTiles() % 2) != 0 ? (player.getNumberOfOwnedTiles() / 2) + 1 : (player.getNumberOfOwnedTiles() / 2);

            if (numFreeRecruits > 5)
                numFreeRecruits = 5;

            while (numFreeRecruits >= 0)
            {
                //play imidiatly or rack it
                Thing t = GameBoard.Game.getRandomThingFromCup();
                player.AddThingToRack(t.getID(), t);
                --numFreeRecruits;
            }
        }

        private void paid(Player player)
        {
            int totalSpent = 0;

            while (totalSpent != 25)
            {
                //prompt to buy a recruit
                //if no break;
                //if yes deduct 5 gold from player gold and increment total
                //play imidiatly or rack it
                Thing t = GameBoard.Game.getRandomThingFromCup();
                player.givePlayerGold(-5);
                player.AddThingToRack(t.getID(), t);
                totalSpent += 5;
            }
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

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private List<Thing> tradins;
    }
}
