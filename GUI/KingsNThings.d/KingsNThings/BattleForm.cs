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
    public partial class BattleForm : Form
    {
        Random rnd = new Random();

        public BattleForm(List <Thing> s1, List <Thing> s2, int num1, int num2)
        {
            InitializeComponent();
            stack1 = new List<Thing>(s1);
            stack2 = new List<Thing>(s2);
            p1Attacks = num1;
            p2Attacks = num2;
            p1TilesClicked = new bool[10];
            p2TilesClicked = new bool[10];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p2clicked == p1Attacks && p1clicked == p2Attacks)
            {
                this.Hide();
            }
        }

        List<Thing> stack1, stack2;
        Image[] images1;
        Image[] images2;
        bool[] p1TilesClicked;
        bool[] p2TilesClicked;
        int p1Attacks, p2Attacks;
        int p1clicked = 0, p2clicked = 0;
        private void BattleForm_Load(object sender, EventArgs e)
        {
            for (int count = 0; count > 9; count++)
            {
                p1TilesClicked[count] = true;
                p2TilesClicked[count] = true;
            }
            int i = 0;
            foreach (Thing thing in stack1){
                
                images1[i]= Image.FromFile(thing.getTexturePath());
                if (i == 0) { pictureBox1.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 1) { pictureBox2.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 2) { pictureBox7.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 3) { pictureBox3.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 4) { pictureBox4.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 5) { pictureBox8.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 6) { pictureBox5.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 7) { pictureBox6.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 8) { pictureBox9.Image = images1[i]; p1TilesClicked[i] = false; }
                if (i == 9) { pictureBox10.Image = images1[i]; p1TilesClicked[i] = false; }

                i++;
            }

            int j = 0;
            foreach (Thing thing in stack2)
            {

                images1[j] = Image.FromFile(thing.getTexturePath());
                if (j == 0) { pictureBox11.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 1) { pictureBox12.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 2) { pictureBox13.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 3) { pictureBox14.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 4) { pictureBox16.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 5) { pictureBox17.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 6) { pictureBox15.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 7) { pictureBox18.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 8) { pictureBox19.Image = images1[j]; p2TilesClicked[j] = false; }
                if (j == 9) { pictureBox20.Image = images1[j]; p2TilesClicked[j] = false; }

                j++;
            }

            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[0] == false)
            {
                p1TilesClicked[0] = true;
                images1[0] = Image.FromFile("x.png");
                pictureBox1.Image = images1[0];
                p2clicked++;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[1] == false)
            {
                p1TilesClicked[1] = true;
                images1[1] = Image.FromFile("x.png");
                pictureBox2.Image = images1[1];
                p2clicked++;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[2] == false)
            {
                p1TilesClicked[2] = true;
                images1[2] = Image.FromFile("x.png");
                pictureBox7.Image = images1[2];
                p2clicked++;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[3] == false)
            {
                p1TilesClicked[3] = true;
                images1[3] = Image.FromFile("x.png");
                pictureBox3.Image = images1[3];
                p2clicked++;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[4] == false)
            {
                p1TilesClicked[4] = true;
                images1[4] = Image.FromFile("x.png");
                pictureBox4.Image = images1[4];
                p2clicked++;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[5] == false)
            {
                p1TilesClicked[5] = true;
                images1[5] = Image.FromFile("x.png");
                pictureBox8.Image = images1[5];
                p2clicked++;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[6] == false)
            {
                p1TilesClicked[6] = true;
                images1[6] = Image.FromFile("x.png");
                pictureBox5.Image = images1[6];
                p2clicked++;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[7] == false)
            {
                p1TilesClicked[7] = true;
                images1[7] = Image.FromFile("x.png");
                pictureBox6.Image = images1[7];
                p2clicked++;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[8] == false)
            {
                p1TilesClicked[8] = true;
                images1[8] = Image.FromFile("x.png");
                pictureBox9.Image = images1[8];
                p2clicked++;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (p1TilesClicked[9] == false)
            {
                p1TilesClicked[9] = true;
                images1[9] = Image.FromFile("x.png");
                pictureBox10.Image = images1[9];
                p2clicked++;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[0] == false)
            {
                p2TilesClicked[0] = true;
                images2[0] = Image.FromFile("x.png");
                pictureBox11.Image = images2[0];
                p1clicked++;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[1] == false)
            {
                p2TilesClicked[1] = true;
                images2[1] = Image.FromFile("x.png");
                pictureBox11.Image = images2[1];
                p1clicked++;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[2] == false)
            {
                p2TilesClicked[2] = true;
                images2[2] = Image.FromFile("x.png");
                pictureBox13.Image = images2[2];
                p1clicked++;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[3] == false)
            {
                p2TilesClicked[3] = true;
                images2[3] = Image.FromFile("x.png");
                pictureBox14.Image = images2[3];
                p1clicked++;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[4] == false)
            {
                p2TilesClicked[4] = true;
                images2[4] = Image.FromFile("x.png");
                pictureBox16.Image = images2[4];
                p1clicked++;
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[5] == false)
            {
                p2TilesClicked[5] = true;
                images2[5] = Image.FromFile("x.png");
                pictureBox17.Image = images2[5];
                p1clicked++;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[6] == false)
            {
                p2TilesClicked[6] = true;
                images2[6] = Image.FromFile("x.png");
                pictureBox15.Image = images2[6];
                p1clicked++;
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[7] == false)
            {
                p2TilesClicked[7] = true;
                images2[7] = Image.FromFile("x.png");
                pictureBox18.Image = images2[7];
                p1clicked++;
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[8] == false)
            {
                p2TilesClicked[8] = true;
                images2[8] = Image.FromFile("x.png");
                pictureBox19.Image = images2[8];
                p1clicked++;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (p2TilesClicked[9] == false)
            {
                p2TilesClicked[9] = true;
                images2[9] = Image.FromFile("x.png");
                pictureBox20.Image = images2[9];
                p1clicked++;
            }
        }

    }
}
