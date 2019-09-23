using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper {

    public class Tile : Control
    {

        private Random rnd = new Random();
        private Color CurrentBackColor;
        public int x;
        public int y;

        public bool bomb;

        public int state;
        public int value;

	    public Tile(bool bomb, int x, int y)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            CurrentBackColor = randomColor;
            this.Width = Minesweep.Instance.tileWidth;
            this.Height = Minesweep.Instance.tileHeight;
            this.x = x;
            this.y = y;
            this.Location = new Point(Width * this.x, Height * this.y);
            this.Size = new Size(this.Width, this.Height);

            this.bomb = bomb;
            this.state = (int)TileState.Empty;
            this.value = 0;
	    }

        public void DetermineValue()
        {
            List<Tile> neighbors = GetNeighbors();
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i].bomb)
                {
                    this.value += 1;
                }
            }
        }

        public List<Tile> GetNeighbors()
        {
            List<Tile> array = new List<Tile>();
            for (int ny = 0; ny < 3; ny++)
            {
                for (int nx = 0; nx < 3; nx++)
                {
                    int xToCheck = (this.x + 1) - nx;
                    int yToCheck = (this.y + 1) - ny;
                    if (xToCheck == this.x && yToCheck == this.y) continue;
                    if (xToCheck < 0 || xToCheck >= Minesweep.Instance.tileArray.GetLength(0)) continue;
                    if (yToCheck < 0 || yToCheck >= Minesweep.Instance.tileArray.GetLength(1)) continue;
                    array.Add(Minesweep.Instance.tileArray[xToCheck, yToCheck]);
                }
            }
            return array;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            Image bg;
            if (Minesweep.debug)
            {
                if (this.bomb)
                {
                    Bitmap questionBG = Minesweeper.Properties.Resources.flag;
                    bg = Image.FromHbitmap(questionBG.GetHbitmap());
                    e.Graphics.DrawImage(bg, srcRect, new Rectangle(0, 0, bg.Width, bg.Height), GraphicsUnit.Pixel);
                    return;
                }
            }
            switch(state) {
                case (int)TileState.Empty:
                    Bitmap emptyBG = Minesweeper.Properties.Resources.empty;
                    bg = Image.FromHbitmap(emptyBG.GetHbitmap());
                    break;
                case (int)TileState.Flagged:
                    Bitmap flagBG = Minesweeper.Properties.Resources.flag;
                    bg = Image.FromHbitmap(flagBG.GetHbitmap());
                    break;
                case (int)TileState.Question:
                    Bitmap questionBG = Minesweeper.Properties.Resources.question;
                    bg = Image.FromHbitmap(questionBG.GetHbitmap());
                    break;
                case (int)TileState.Mine:
                    Bitmap mineBG = Minesweeper.Properties.Resources.mine;
                    bg = Image.FromHbitmap(mineBG.GetHbitmap());
                    break;
                case (int)TileState.BlewUp:
                    Bitmap blewBG = Minesweeper.Properties.Resources.mineRed;
                    bg = Image.FromHbitmap(blewBG.GetHbitmap());
                    break;
                case (int)TileState.Clicked:
                    Bitmap clickedBG;
                    switch(value) {
                        case 0:
                            clickedBG = Minesweeper.Properties.Resources.emptyClicked;
                            break;
                        case 1:
                            clickedBG = Minesweeper.Properties.Resources._1;
                            break;
                        case 2:
                            clickedBG = Minesweeper.Properties.Resources._2;
                            break;
                        case 3:
                            clickedBG = Minesweeper.Properties.Resources._3;
                            break;
                        case 4:
                            clickedBG = Minesweeper.Properties.Resources._4;
                            break;
                        case 5:
                            clickedBG = Minesweeper.Properties.Resources._5;
                            break;
                        case 6:
                            clickedBG = Minesweeper.Properties.Resources._6;
                            break;
                        case 7:
                            clickedBG = Minesweeper.Properties.Resources._7;
                            break;
                        case 8:
                            clickedBG = Minesweeper.Properties.Resources._8;
                            break;
                        default:
                            clickedBG = Minesweeper.Properties.Resources.emptyClicked;
                            break;
                    }
                    bg = Image.FromHbitmap(clickedBG.GetHbitmap());
                    break;
                default:
                    Bitmap defaultBG = Minesweeper.Properties.Resources.empty;
                    bg = Image.FromHbitmap(defaultBG.GetHbitmap());
                    break;
            }
            e.Graphics.DrawImage(bg, srcRect, new Rectangle(0, 0, bg.Width, bg.Height), GraphicsUnit.Pixel);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Minesweep.Instance.TileClick(this.x, this.y);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            Invalidate();
        }
    }
}