using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {

        public Minesweep mineRef;
        public Panel boardPanel;
        public Label debugLabel;

        public Game(int difficulty)
        {
            InitializeComponent();
            boardPanel = this.gamePanel;
            debugLabel = this.label1;
            mineRef = new Minesweep(this, difficulty);
        }

        private void flagButton_Click(object sender, EventArgs e)
        {
            mineRef.FlagBtnClick((PictureBox)sender);
        }
    }
}