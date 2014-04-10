namespace KingsNThings.Forms
{
    partial class DicerollWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DiceRollButton = new System.Windows.Forms.Button();
            this.DiceRollTextBox = new System.Windows.Forms.TextBox();
            this.DicerollLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DiceRollButton
            // 
            this.DiceRollButton.Location = new System.Drawing.Point(90, 126);
            this.DiceRollButton.Name = "DiceRollButton";
            this.DiceRollButton.Size = new System.Drawing.Size(100, 20);
            this.DiceRollButton.TabIndex = 0;
            this.DiceRollButton.Text = "Roll Dice";
            this.DiceRollButton.UseVisualStyleBackColor = true;
            this.DiceRollButton.Click += new System.EventHandler(this.diceRollButton_Click);
            // 
            // DiceRollTextBox
            // 
            this.DiceRollTextBox.Location = new System.Drawing.Point(90, 91);
            this.DiceRollTextBox.Name = "DiceRollTextBox";
            this.DiceRollTextBox.Size = new System.Drawing.Size(100, 20);
            this.DiceRollTextBox.TabIndex = 1;
            // 
            // DicerollLabel
            // 
            this.DicerollLabel.Location = new System.Drawing.Point(33, 28);
            this.DicerollLabel.Name = "DicerollLabel";
            this.DicerollLabel.Size = new System.Drawing.Size(207, 45);
            this.DicerollLabel.TabIndex = 2;
            this.DicerollLabel.Text = "Please enter a valid dice roll value ( 2- 12 ) or leave the box empty for a rando" +
    "m roll.";
            this.DicerollLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // DicerollWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.DicerollLabel);
            this.Controls.Add(this.DiceRollTextBox);
            this.Controls.Add(this.DiceRollButton);
            this.Name = "DicerollWindow";
            this.Text = "DicerollWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiceRollButton;
        private System.Windows.Forms.TextBox DiceRollTextBox;
        private System.Windows.Forms.Label DicerollLabel;
    }
}