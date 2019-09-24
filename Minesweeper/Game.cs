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
        public PictureBox smileBtn;
        public Image smileImg;

        public Game(int difficulty)
        {
            InitializeComponent();
            boardPanel = this.gamePanel;
            debugLabel = this.label1;
            smileBtn = this.smileButton;
            smileImg = smileBtn.Image;
            mineRef = new Minesweep(this, difficulty);
        }

        private void flagButton_Click(object sender, EventArgs e)
        {
            mineRef.FlagBtnClick((PictureBox)sender);
        }

        public void ChangeSmile(Image img)
        {
            smileImg = img;
            smileBtn.Image = img;
        }

        private void smileButton_Click(object sender, EventArgs e)
        {
            mineRef.SmileClick((PictureBox)sender);
        }

        private void smileButton_MouseDown(object sender, MouseEventArgs e)
        {
            smileBtn.Image = Properties.Resources.smileClicked;
        }

        private void smileButton_MouseUp(object sender, MouseEventArgs e)
        {
            smileBtn.Image = smileImg;
        }
    }
}