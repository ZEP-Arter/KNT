using GameLogic.Utils;
using KingsNThings.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KingsNThings.Forms
{
    public partial class DicerollWindow : Form
    {
        public DicerollWindow()
        {
            InitializeComponent();
        }

        private void diceRollButton_Click(object sender, EventArgs e)
        {
            string diceroll = this.DiceRollTextBox.Text;

            int roll = -1;

            if (diceroll.Equals(""))
                roll = DiceRoller.Roll.rollDice();
            else
            {
                try
                {
                    roll = Int32.Parse(diceroll);
                }
                catch (Exception ex)
                {
                    roll = DiceRoller.Roll.rollDice();
                }

                if (roll < 2 || roll > 12)
                    roll = -1;
            }

            if (roll != -1)
                KNT_Game.me.setDiceRoll(roll);
            else
                KNT_Game.me.setDiceRoll(DiceRoller.Roll.rollDice());

            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
