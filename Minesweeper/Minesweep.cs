using System;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper;

public class Minesweep
{
    public static Minesweep Instance;
    public Game gameForm;
    public int gameWidth;
    public int gameHeight;
    public Tile[,] tileArray;

    //public 

    public int tileWidth = 20;
    public int tileHeight = 20;

	public Minesweep(Game form, string difficulty)
	{
        gameForm = form;
        Instance = this;
        switch(difficulty) {
            case "Beginner":

        int gridX = 16, gridY = gridX;
        tileWidth = Convert.ToInt32((gameForm.ClientSize.Width - 3) / gridX);
        tileHeight = tileWidth;
        InitGameGrid(gridX, gridY);
	}

    public void InitGameGrid(int width, int height)
    {
        tileArray = new Tile[width + 1, height + 1];
        gameWidth = width;
        gameHeight = height;
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                Tile tileObj = new Tile(false, x, y);
                tileArray[x,y] = tileObj;
                RenderToGameGrid(tileObj);
            }
        }
        gameForm.boardPanel.Size = new Size(width * tileWidth, height * tileHeight);
        gameForm.boardPanel.Left = (gameForm.ClientSize.Width - gameForm.boardPanel.Width) / 2;
        gameForm.boardPanel.Top = (gameForm.ClientSize.Height - (height * tileHeight)) - 5;
    }

    public void RenderToGameGrid(Tile tile)
    {
        gameForm.boardPanel.Controls.Add(tile);
        //gameForm.Controls.Add(tile);
        //gameForm.debugLabel.Text += " " + tile.Location.X.ToString() + " " + tile.Location.Y.ToString();
    }
}
