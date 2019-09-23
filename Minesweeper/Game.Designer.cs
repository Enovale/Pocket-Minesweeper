namespace Minesweeper
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.label1 = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.flagButton = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(63, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "label1";
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(3, 48);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(234, 243);
            // 
            // flagButton
            // 
            this.flagButton.Image = ((System.Drawing.Image)(resources.GetObject("flagButton.Image")));
            this.flagButton.Location = new System.Drawing.Point(195, 3);
            this.flagButton.Name = "flagButton";
            this.flagButton.Size = new System.Drawing.Size(42, 42);
            this.flagButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flagButton.Click += new System.EventHandler(this.flagButton_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.flagButton);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.label1);
            this.Name = "Game";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.PictureBox flagButton;
    }
}

