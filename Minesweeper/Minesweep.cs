using System;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper;

public class Minesweep
{
    public static Minesweep Instance;
    public Random random = new Random();
    public Game gameForm;
    public int gameWidth;
    public int gameHeight;
    public Tile[,] tileArray;

    public bool firstClick = true;
    public bool flagSelect = false;

    public int tileWidth = 20;
    public int tileHeight = 20;

	public Minesweep(Game form, int difficulty)
	{
        gameForm = form;
        Instance = this;
        firstClick = true;
        int gridX = 16, gridY = gridX;
        int bombAmount = 10;
        switch (difficulty)
        {
            case (int)Difficulty.Beginner:
                gridX = 9;
                gridY = 9;
                bombAmount = 10;
                break;
            case (int)Difficulty.Intermediate:
                gridX = 16;
                gridY = 16;
                bombAmount = 40;
                break;
            case (int)Difficulty.Advanced:
                gridX = 16;
                gridY = 17;
                bombAmount = 70;
                break;
            default:
                gridX = 9;
                gridY = 9;
                bombAmount = 10;
                break;
        }
        tileWidth = Convert.ToInt32((gameForm.ClientSize.Width - 3) / gridX);
        tileHeight = tileWidth;
        InitGameGrid(gridX, gridY);
        AddBombs(bombAmount);
	}

    public int RandomNumber(int min, int max)
    {
        return random.Next(min, max);
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

    public void RedrawGameGrid()
    {
        for (int y = 0; y <= gameHeight; y++)
        {
            for (int x = 0; x <= gameWidth; x++)
            {
                tileArray[x, y].Invalidate();
            }
        }
        gameForm.boardPanel.Size = new Size(gameWidth * tileWidth, gameHeight * tileHeight);
        gameForm.boardPanel.Left = (gameForm.ClientSize.Width - gameForm.boardPanel.Width) / 2;
        gameForm.boardPanel.Top = (gameForm.ClientSize.Height - (gameHeight * tileHeight)) - 5;
    }

    public void RenderToGameGrid(Tile tile)
    {
        gameForm.boardPanel.Controls.Add(tile);
        //gameForm.Controls.Add(tile);
        //gameForm.debugLabel.Text += " " + tile.Location.X.ToString() + " " + tile.Location.Y.ToString();
    }

    public void AddBombs(int amount)
    {
        for (int i = 0; i <= amount - 1; i++)
        {
            int randX = RandomNumber(0, gameWidth);
            int randY = RandomNumber(0, gameHeight);
            if (!(tileArray[randX, randY].bomb))
            {
                tileArray[randX, randY].bomb = true;
            }
            else
            {
                i--;
            }
        }
    }

    public void CalcValues()
    {
        for (int y = 0; y <= gameHeight; y++)
        {
            for (int x = 0; x <= gameWidth; x++)
            {
                tileArray[x, y].DetermineValue();
            }
        }
    }

    private void MoveBombAway(int x, int y)
    {
        tileArray[x, y].state = (int)TileState.Empty;
        int randX = RandomNumber(0, gameWidth);
        int randY = RandomNumber(0, gameHeight);
        tileArray[randX, randY].Invalidate();
        tileArray[x, y].Invalidate();
        if (!(tileArray[randX, randY].bomb))
        {
            if (randX != x && randY != y)
            {
                tileArray[randX, randY].bomb = true;
                tileArray[randX, randY].Invalidate();
                tileArray[x, y].Invalidate();
            }
            else
            {
                MoveBombAway(x, y);
            }
        }
        else
        {
            MoveBombAway(x, y);
        }
    }

    public void FlagBtnClick(PictureBox btnObj)
    {
        if (flagSelect == false)
        {
            flagSelect = true; 
            Bitmap emptyBG = Minesweeper.Properties.Resources.flagClicked;
            btnObj.Image = Image.FromHbitmap(emptyBG.GetHbitmap());
        }
        else
        {
            flagSelect = false;
            Bitmap emptyBG = Minesweeper.Properties.Resources.flag;
            btnObj.Image = Image.FromHbitmap(emptyBG.GetHbitmap());
        }
    }

    /// <summary>
    /// Upon clicking a tile
    /// </summary>
    public void TileClick(int x, int y)
    {
        Tile tileObj = tileArray[x, y];
        bool nothing = firstClick;
        if (firstClick)
        {
            if (tileObj.bomb)
            {
                MoveBombAway(x, y);
            }
            firstClick = false;
            CalcValues();
            TileClick(x, y);
            return;
        }
        if (flagSelect)
        {
            switch (tileObj.state)
            {
                //case 
            }
        }
        else
        {
            if (tileObj.bomb)
            {
                // die
                Death();
                return;
            }
            else
            {
                tileObj.state = (int)TileState.Clicked;
            }
        }
        tileObj.Invalidate();
    }

    public void OpenRegion(int x, int y)
    {
        // stub
    }

    public void Death()
    {
        gameForm.Close();
    }
}
