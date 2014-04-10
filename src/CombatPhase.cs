using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class CombatPhase : Phase
    {
        public CombatPhase() :
            base("Combat")
        {
            combatUnresolved = false;
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            flagCombat();
            if (currentState != State.IN_PROGRESS)
                beginPhase();
            if (currentPlayer == null)
                currentPlayer = _players[0];

            if (currentPlayer.getInPhase())
            {
                changePlayer();
            }

            if (allDone())
            {
                if (!allCombatResolved())
                {
                    beginPhase();
                    currentPlayer = _players[0];
                }
                else
                {
                    this.endPhase();
                }
            }
            
        }

        private void flagCombat()
        {
            List<Tile> map = GameBoard.Game.getMap().getHexList();
            int c = 0;
            foreach (Tile t in map)
            {
                c = 0;
                for(int i=1; i<5; i++)
                {
                    if(t.doesPlayerHaveStack(i))
                        c++;
                }
                if (c >= 2)
                    t.setCFlag(true);
                else
                    t.setCFlag(false);
            }
        }

        private bool allCombatResolved()
        {
            foreach (Tile t in GameBoard.Game.getMap().getHexList())
            {
                if (t.getCFlag())
                    return false;
            }

            return true;
        }

        //public void resolveCombat(Tile t)
        //{
        //    bool resolved = false;
        //    int attacker = t.getPlayer().getPlayerNumber();
        //    int defender = 0;
        //    for (int i = 1; i < 5; i++)
        //    {
        //        if (i != currentPlayer.getPlayerNumber())
        //        {
        //            if (t.doesPlayerHaveStack(i))
        //                defender = i;
        //        }
        //    }

        //    while (!resolved)
        //    {
                
        //        List<Thing> attackerStack = t.getPlayerStack(attacker);
        //        List<Thing> defenderStack = t.getPlayerStack(defender);



        //        //List<Thing> attackerMagicStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
        //        //List<Thing> defenderMagicStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);

        //        //List<Thing> attackerRangeStack = findAttribute(attackerStack, Attributes.CombatAttributes.RANGED);
        //        //List<Thing> defenderRangeStack = findAttribute(defenderStack, Attributes.CombatAttributes.RANGED);

        //        //List<Thing> attackerMeleeStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
        //        //List<Thing> defenderMeleeStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);
        //    }
        //}

        private List<Thing> findAttribute(List<Thing> things, Attributes.CombatAttributes a)
        {
            List<Thing> returnList = new List<Thing>();
            foreach (Thing thing in things)
            {
                foreach (Attributes.CombatAttributes att in thing.attributes)
                {
                    if (att.Equals(a))
                    {
                        returnList.Add(thing);
                    }
                }
            }
            return returnList;
        }

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private bool combatUnresolved;
        private Board map;
    }
}
