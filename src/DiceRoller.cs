using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameLogic
{
    public class DiceRoller
    {
        public int fixDiceRoll(int i)
        {
            if (i > 6)
                return dice[5];

            return dice[i - 1];
        }

        public int rollDice()
        {
            rollingDice();

            System.DateTime now = System.DateTime.Now;

            Random r = new Random(now.Millisecond + (++numRolls));

            return dice[r.Next(dice.Count)];
        }

        private DiceRoller()
        {
            numRolls = 0;
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

        private static void rollingDice()
        {
            Console.Write("Rolling .");
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.Write('.');
            Thread.Sleep(200);
            Console.WriteLine('.');
            Thread.Sleep(200);
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
        private int numRolls;
    }
}
