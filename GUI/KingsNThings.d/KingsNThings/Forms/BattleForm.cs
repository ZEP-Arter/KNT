using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameLogic;
using GameLogic.Things;

namespace KingsNThings.Forms
{
    public partial class BattleForm : Form
    {
        Random rnd = new Random();

        public BattleForm(List<Thing> aStack, List<Thing> dStack, int aHits, int dHits, int aPlayerNum, int dPlayerNum)
        {
            InitializeComponent();
            attackers = aStack;
            defenders = dStack;
            defenderHitsTaken = aHits;
            attackerHitsTaken = dHits;
            defendersClicked = new bool[10];
            attackersClicked = new bool[10];

            defenderLabel.Text = String.Format("Defender: Player {0}, Apply {1} hits", dPlayerNum, defenderHitsTaken);
            attackerLabel.Text = String.Format("Attacker: Player {0}, Apply {1} hits", aPlayerNum, attackerHitsTaken);

            var trace = new StackTrace(true);
            var frame = trace.GetFrame(0);
            string sourceCodeFile = Path.GetDirectoryName(frame.GetFileName());
            sourceDirectory = Path.GetDirectoryName(sourceCodeFile);
            xImage = Image.FromFile(Path.Combine(sourceDirectory, "KNT_Game_FinalContent\\", "images\\x.png"));
            init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = defenders.Count-1; i >= 0; i--)
            {
                if (defendersClicked[i] == true)
                {
                    defenders.RemoveAt(i);
                }
            }
            for (int i = attackers.Count - 1; i >= 0; i--)
            {
                if (attackersClicked[i] == true)
                {
                    attackers.RemoveAt(i);
                }
            }
            
            this.Close();
        }

        List<Thing> attackers, defenders;
        Image[] images1 = new Image[10];
        Image[] images2 = new Image[10];
        Image xImage;
        bool[] defendersClicked;
        bool[] attackersClicked;
        int defenderHitsTaken, attackerHitsTaken;
        string sourceDirectory;

        public List<Thing> getAttackerStack()
        { return attackers; }

        public List<Thing> getDefenderStack()
        { return defenders; }

        private void BattleForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
        }

        private void init()
        {
            for (int count = 0; count < 10; count++)
            {
                defendersClicked[count] = true;
                attackersClicked[count] = true;
            }
            int i = 0;
            foreach (Thing thing in defenders)
            {

                images1[i] = Image.FromFile(Path.Combine(sourceDirectory, "KNT_Game_FinalContent\\", thing.getTexturePath()));

                if (i == 0) { pictureBox1.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 1) { pictureBox2.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 2) { pictureBox7.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 3) { pictureBox3.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 4) { pictureBox4.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 5) { pictureBox8.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 6) { pictureBox5.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 7) { pictureBox6.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 8) { pictureBox9.Image = images1[i]; defendersClicked[i] = false; }
                if (i == 9) { pictureBox10.Image = images1[i]; defendersClicked[i] = false; }

                i++;
            }

            int j = 0;
            foreach (Thing thing in attackers)
            {

                images1[j] = Image.FromFile(Path.Combine(sourceDirectory, "WindowsGame1Content\\", thing.getTexturePath()));
                if (j == 0) { pictureBox11.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 1) { pictureBox12.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 2) { pictureBox13.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 3) { pictureBox14.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 4) { pictureBox16.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 5) { pictureBox17.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 6) { pictureBox15.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 7) { pictureBox18.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 8) { pictureBox19.Image = images1[j]; attackersClicked[j] = false; }
                if (j == 9) { pictureBox20.Image = images1[j]; attackersClicked[j] = false; }

                j++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (defendersClicked[0] == false && defenderHitsTaken > 0)
            {
                defendersClicked[0] = true;
                images1[0] = xImage;
                pictureBox1.Image = images1[0];
                defenderHitsTaken--;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (defendersClicked[1] == false && defenderHitsTaken > 0)
            {
                defendersClicked[1] = true;
                images1[1] = xImage;
                pictureBox2.Image = images1[1];
                defenderHitsTaken--;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (defendersClicked[2] == false && defenderHitsTaken > 0)
            {
                defendersClicked[2] = true;
                images1[2] = xImage;
                pictureBox7.Image = images1[2];
                defenderHitsTaken--;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (defendersClicked[3] == false && defenderHitsTaken > 0)
            {
                defendersClicked[3] = true;
                images1[3] = xImage;
                pictureBox3.Image = images1[3];
                defenderHitsTaken--;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (defendersClicked[4] == false && defenderHitsTaken > 0)
            {
                defendersClicked[4] = true;
                images1[4] = xImage;
                pictureBox4.Image = images1[4];
                defenderHitsTaken--;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (defendersClicked[5] == false && defenderHitsTaken > 0)
            {
                defendersClicked[5] = true;
                images1[5] = xImage;
                pictureBox8.Image = images1[5];
                defenderHitsTaken--;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (defendersClicked[6] == false && defenderHitsTaken > 0)
            {
                defendersClicked[6] = true;
                images1[6] = xImage;
                pictureBox5.Image = images1[6];
                defenderHitsTaken--;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (defendersClicked[7] == false && defenderHitsTaken > 0)
            {
                defendersClicked[7] = true;
                images1[7] = xImage;
                pictureBox6.Image = images1[7];
                defenderHitsTaken--;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (defendersClicked[8] == false && defenderHitsTaken > 0)
            {
                defendersClicked[8] = true;
                images1[8] = xImage;
                pictureBox9.Image = images1[8];
                defenderHitsTaken--;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (defendersClicked[9] == false && defenderHitsTaken > 0)
            {
                defendersClicked[9] = true;
                images1[9] = xImage;
                pictureBox10.Image = images1[9];
                defenderHitsTaken--;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (attackersClicked[0] == false && attackerHitsTaken > 0)
            {
                attackersClicked[0] = true;
                images2[0] = xImage;
                pictureBox11.Image = images2[0];
                attackerHitsTaken--;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (attackersClicked[1] == false && attackerHitsTaken > 0)
            {
                attackersClicked[1] = true;
                images2[1] = xImage;
                pictureBox12.Image = images2[1];
                attackerHitsTaken--;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (attackersClicked[2] == false && attackerHitsTaken > 0)
            {
                attackersClicked[2] = true;
                images2[2] = xImage;
                pictureBox13.Image = images2[2];
                attackerHitsTaken--;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (attackersClicked[3] == false && attackerHitsTaken > 0)
            {
                attackersClicked[3] = true;
                images2[3] = xImage;
                pictureBox14.Image = images2[3];
                attackerHitsTaken--;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (attackersClicked[4] == false && attackerHitsTaken > 0)
            {
                attackersClicked[4] = true;
                images2[4] = xImage;
                pictureBox16.Image = images2[4];
                attackerHitsTaken--;
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (attackersClicked[5] == false && attackerHitsTaken > 0)
            {
                attackersClicked[5] = true;
                images2[5] = xImage;
                pictureBox17.Image = images2[5];
                attackerHitsTaken--;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (attackersClicked[6] == false && attackerHitsTaken > 0)
            {
                attackersClicked[6] = true;
                images2[6] = xImage;
                pictureBox15.Image = images2[6];
                attackerHitsTaken--;
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (attackersClicked[7] == false && attackerHitsTaken > 0)
            {
                attackersClicked[7] = true;
                images2[7] = xImage;
                pictureBox18.Image = images2[7];
                attackerHitsTaken--;
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (attackersClicked[8] == false && attackerHitsTaken > 0)
            {
                attackersClicked[8] = true;
                images2[8] = xImage;
                pictureBox19.Image = images2[8];
                attackerHitsTaken--;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (attackersClicked[9] == false && attackerHitsTaken > 0)
            {
                attackersClicked[9] = true;
                images2[9] = xImage;
                pictureBox20.Image = images2[9];
                attackerHitsTaken--;
            }
        }

    }
}
