using System;
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

        public bool revealed;
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
	    }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Declare and instantiate a new pen.  
            using (System.Drawing.Brush myPen = new System.Drawing.SolidBrush(CurrentBackColor))
            {
                // Draw an aqua rectangle in the rectangle represented by the control.  
                e.Graphics.FillRectangle(myPen, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
                e.Graphics.DrawString(this.x.ToString() + " " + this.Width, this.Font, new System.Drawing.SolidBrush(Color.Black), 0, 0);
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            Invalidate();
        }
    }
}