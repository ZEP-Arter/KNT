using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowLogic
{
    public partial class Form1 : Form
    {
        List<string> thing1 = new List<string>();
        List<string> thing2 = new List<string>();
        int counter1;
        int counter2;
        public Form1(List <Thing> stack1, List <Thing> stack2)
        {
            InitializeComponent();
            counter1 = 0;
            counter2 = 0;
            for (int i = 1; i < stack1.Count; i++)
            {
                thing1.Add(stack1.IndexOf(i).name);//Make sure this is right, adding every name into the List
                counter1 = counter1 + stack1.IndexOf(i).CombatValue; //again, not sure if it'll work properly
            }

            listBox1.DataSource = thing1; //Makes the list of strings appear in the listbox

            for (int i = 1; i < stack2.Count; i++)
            {
                thing1.Add(stack2.IndexOf(i).name); //Make sure this is right, adding every name into the List
                counter1 = counter1 + stack2.IndexOf(i).CombatValue; //again, not sure if it'll work properly
            }

            listBox2.DataSource = thing2; //Makes the list of strings appear in the listbox
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
