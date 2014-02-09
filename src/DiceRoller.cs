using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    class DiceRoller
    {
        public int fixDiceRoll(int i)
        {
            if (i > 6)
                return dice[5];

            return dice[i - 1];
        }

        public int rollDice()
        {
            Random r = new Random();

            return dice[r.Next(dice.Count)];
        }

        private DiceRoller()
        {
            dice = new List<int>(6);
            initDice();
        }

        private void initDice()
        {
            dice.Add(1);
            dice.Add(2);
            dice.Add(3);
            dice.Add(4);
            dice.Add(5);
            dice.Add(6);
        }

        private static DiceRoller roll;

        public static DiceRoller Roll
        {
            get
            {
                if (roll == null)
                    return roll = new DiceRoller();

                return roll;
            }
        }

        List<int> dice;
    }
}
