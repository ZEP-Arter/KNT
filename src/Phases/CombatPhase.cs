using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Managers;
using GameLogic.Things;

namespace GameLogic.Phases
{
    public class CombatPhase : Phase
    {
        public CombatPhase() :
            base("Combat")
        {
            map = GameBoard.Game.getMap();
            combatUnresolved = false;
        }

        public override void playPhase(KNT_Client.Networkable.Player player)
        {
            _player = player;
        }

        private void combat()
        {
            //foreach(Tile t in map.getHexList())
            //{
            //    if (t.getCFlag())
            //        combatUnresolved = true;
            //}
            //while (combatUnresolved)
            //{
            //    foreach (Player p in _players)
            //    {
            //        //Wait for Player to click on combat hex

            //    }
            //    combatUnresolved = false;
            //    foreach (Tile t in map.getHexList())
            //    {
            //        if (t.getCFlag())
            //            combatUnresolved = true;
            //    }
            //}
        }

        public void resolveCombat(KNT_Client.Networkable.Tile t)
        {
            //bool resolved = false;
            //while (!resolved)
            //{
            //    List<Thing> attackerStack = t.p1Stack;
            //    List<Thing> defenderStack = t.p2Stack;

            //    List<Thing> attackerMagicStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
            //    List<Thing> defenderMagicStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);
                
            //    //ROLL FOR HITS
            //    //APPLY HITS

            //    List<Thing> attackerRangeStack = findAttribute(attackerStack, Attributes.CombatAttributes.RANGED);
            //    List<Thing> defenderRangeStack = findAttribute(defenderStack, Attributes.CombatAttributes.RANGED);

            //    List<Thing> attackerMeleeStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
            //    List<Thing> defenderMeleeStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);
            //}
        }

        private List<KNT_Client.Networkable.Thing> findAttribute(List<KNT_Client.Networkable.Thing> things, Attributes.CombatAttributes a)
        {
            List<KNT_Client.Networkable.Thing> returnList = new List<KNT_Client.Networkable.Thing>();
            //foreach (Thing thing in things)
            //{
            //    foreach (Attributes.CombatAttributes att in thing.attributes)
            //    {
            //        if (att.Equals(a))
            //        {
            //            returnList.Add(thing);
            //        }
            //    }
            //}
            return returnList;
        }

        private bool combatUnresolved;
        private Board map;
    }
}
