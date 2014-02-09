using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Attributes
    {
        public enum CombatAttributes
        {
            FLYING, // triangel
            MAGIC, // drawn star
            CHARGE, //can charge in combat (large C)
            RANGED, // (large R)
            SPECIAL, // has special ability ( kleene star * )
            PLUS_HITS // paranthesis around combat score is multi hit in combat ( can take more then one hit in combat )
        }
    }
}
