using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace KingsNThings
{
    public partial class PlayerNameWindow : Form
    {
        string name = "";
        
        //To get in code, use .Show() method.
        public PlayerNameWindow() //Not sure if this will work
        {
            InitializeComponent();
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void PlayerNameWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (name != "" && name.Length <= 14)
            {
                //p.setName(name); // Just need to change this 
                this.Close(); // this gets rid of all the data of the form, use this or if having problems, this.hide() works
            }
            else
            {
                textBox1.Text = "Invalid Name. Try Again.";
            }

        }
    }
}
