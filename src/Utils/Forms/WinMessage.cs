using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameLogic.Utils.Forms
{
    public partial class WinMessage : Form
    {
        public WinMessage(string playerName)
        {
            InitializeComponent();

            this.WinLabel.Text = string.Format("{0} won the game! Please press [OK] to close the game.", playerName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WinButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WINNER!!!");

            Environment.Exit(1);
        }
    }
}
