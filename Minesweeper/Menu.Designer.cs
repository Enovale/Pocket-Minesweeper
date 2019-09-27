namespace Minesweeper
{
    partial class Menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.logoLabel = new System.Windows.Forms.Label();
            this.customPanel = new System.Windows.Forms.Panel();
            this.customBombsField = new System.Windows.Forms.NumericUpDown();
            this.customBombsLabel = new System.Windows.Forms.Label();
            this.customHeightLabel = new System.Windows.Forms.Label();
            this.customHeightField = new System.Windows.Forms.NumericUpDown();
            this.customWidthLabel = new System.Windows.Forms.Label();
            this.customLabel = new System.Windows.Forms.Label();
            this.customWidthField = new System.Windows.Forms.NumericUpDown();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.helpButton = new System.Windows.Forms.Button();
            this.customPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // difficultyBox
            // 
            this.difficultyBox.Items.Add("Beginner");
            this.difficultyBox.Items.Add("Intermediate");
            this.difficultyBox.Items.Add("Advanced");
            this.difficultyBox.Items.Add("Custom");
            this.difficultyBox.Location = new System.Drawing.Point(70, 225);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(100, 22);
            this.difficultyBox.TabIndex = 1;
            // 
            // logoLabel
            // 
            this.logoLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.logoLabel.Location = new System.Drawing.Point(0, 24);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(240, 45);
            this.logoLabel.Text = "Minesweeper";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customPanel
            // 
            this.customPanel.Controls.Add(this.customBombsField);
            this.customPanel.Controls.Add(this.customBombsLabel);
            this.customPanel.Controls.Add(this.customHeightLabel);
            this.customPanel.Controls.Add(this.customHeightField);
            this.customPanel.Controls.Add(this.customWidthLabel);
            this.customPanel.Controls.Add(this.customLabel);
            this.customPanel.Controls.Add(this.customWidthField);
            this.customPanel.Location = new System.Drawing.Point(39, 73);
            this.customPanel.Name = "customPanel";
            this.customPanel.Size = new System.Drawing.Size(170, 97);
            // 
            // customBombsField
            // 
            this.customBombsField.Location = new System.Drawing.Point(91, 75);
            this.customBombsField.Name = "customBombsField";
            this.customBombsField.Size = new System.Drawing.Size(79, 22);
            this.customBombsField.TabIndex = 7;
            this.customBombsField.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // customBombsLabel
            // 
            this.customBombsLabel.Location = new System.Drawing.Point(0, 75);
            this.customBombsLabel.Name = "customBombsLabel";
            this.customBombsLabel.Size = new System.Drawing.Size(46, 22);
            this.customBombsLabel.Text = "Mines:";
            this.customBombsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customHeightLabel
            // 
            this.customHeightLabel.Location = new System.Drawing.Point(0, 49);
            this.customHeightLabel.Name = "customHeightLabel";
            this.customHeightLabel.Size = new System.Drawing.Size(46, 22);
            this.customHeightLabel.Text = "Height:";
            this.customHeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customHeightField
            // 
            this.customHeightField.Location = new System.Drawing.Point(91, 49);
            this.customHeightField.Name = "customHeightField";
            this.customHeightField.Size = new System.Drawing.Size(79, 22);
            this.customHeightField.TabIndex = 3;
            this.customHeightField.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // customWidthLabel
            // 
            this.customWidthLabel.Location = new System.Drawing.Point(0, 23);
            this.customWidthLabel.Name = "customWidthLabel";
            this.customWidthLabel.Size = new System.Drawing.Size(46, 22);
            this.customWidthLabel.Text = "Width:";
            this.customWidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customLabel
            // 
            this.customLabel.Location = new System.Drawing.Point(0, 0);
            this.customLabel.Name = "customLabel";
            this.customLabel.Size = new System.Drawing.Size(170, 20);
            this.customLabel.Text = "Custom Game";
            this.customLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customWidthField
            // 
            this.customWidthField.Location = new System.Drawing.Point(91, 23);
            this.customWidthField.Name = "customWidthField";
            this.customWidthField.Size = new System.Drawing.Size(79, 22);
            this.customWidthField.TabIndex = 0;
            this.customWidthField.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // toolBar
            // 
            this.toolBar.Name = "toolBar";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(187, 225);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(22, 22);
            this.helpButton.TabIndex = 3;
            this.helpButton.Text = "?";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.customPanel);
            this.Controls.Add(this.logoLabel);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Menu";
            this.Text = "Minesweeper";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            this.customPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel customPanel;
        private System.Windows.Forms.NumericUpDown customWidthField;
        private System.Windows.Forms.Label customWidthLabel;
        private System.Windows.Forms.Label customLabel;
        private System.Windows.Forms.Label customHeightLabel;
        private System.Windows.Forms.NumericUpDown customHeightField;
        private System.Windows.Forms.Label customBombsLabel;
        private System.Windows.Forms.NumericUpDown customBombsField;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.Button helpButton;
    }
}