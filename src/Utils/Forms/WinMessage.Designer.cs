namespace GameLogic.Utils.Forms
{
    partial class WinMessage
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
            this.WinLabel = new System.Windows.Forms.Label();
            this.WinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WinLabel
            // 
            this.WinLabel.AutoSize = true;
            this.WinLabel.Location = new System.Drawing.Point(64, 38);
            this.WinLabel.Name = "WinLabel";
            this.WinLabel.Size = new System.Drawing.Size(256, 13);
            this.WinLabel.TabIndex = 0;
            this.WinLabel.Text = "You have won! Please press [OK] to close the game.";
            this.WinLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // WinButton
            // 
            this.WinButton.Location = new System.Drawing.Point(153, 77);
            this.WinButton.Name = "WinButton";
            this.WinButton.Size = new System.Drawing.Size(75, 23);
            this.WinButton.TabIndex = 1;
            this.WinButton.Text = "OK";
            this.WinButton.UseVisualStyleBackColor = true;
            this.WinButton.Click += new System.EventHandler(this.WinButton_Click);
            // 
            // WinMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 112);
            this.Controls.Add(this.WinButton);
            this.Controls.Add(this.WinLabel);
            this.Name = "WinMessage";
            this.Text = "WinMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinLabel;
        private System.Windows.Forms.Button WinButton;
    }
}