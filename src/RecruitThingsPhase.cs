using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class RecruitThingsPhase : Phase
    {
        public RecruitThingsPhase(List<Player> players) :
            base("RecruitThings")
        {
            _players = players;
            tradins = new List<Thing>();
        }

        private void recruiteThigns()
        {
            this.beginPhase();

            foreach (Player p in _players)
            {
                //prompt to skip phase?
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
                player.AddThingToRack(GameBoard.Game.getRandomThingFromCup());
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
                player.givePlayerGold(-5);
                player.AddThingToRack(GameBoard.Game.getRandomThingFromCup());
                totalSpent += 5;
            }
        }

        private void trades(Player player)
        {
            int numTradins = tradins.Count / 2;

            while (numTradins >= 0)
            {
                //play imidiatly or rack it
                player.AddThingToRack(GameBoard.Game.getRandomThingFromCup());
                --numTradins;
            }
        }

        private List<Player> _players;
        private List<Thing> tradins;
    }
}
