using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper;

public class Minesweep
{

    public static bool debug = false;

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
        tileArray[x, y].bomb = false;
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

    public void SmileClick(PictureBox smileObj)
    {
        Minesweeper.Menu f = new Minesweeper.Menu();
        f.Closed += (s, args) => gameForm.Close();
        f.Show();
        gameForm.Hide();
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
            List<Tile> neighbors = tileObj.GetNeighbors();
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i].bomb == true)
                {
                    MoveBombAway(neighbors[i].x, neighbors[i].y);
                }
            }
            if (tileObj.bomb)
            {
                MoveBombAway(x, y);
            }
            CalcValues();
            firstClick = false;
            TileClick(x, y);
            return;
        }
        if (flagSelect)
        {
            switch (tileObj.state)
            {
                case (int)TileState.Empty:
                    tileObj.state = (int)TileState.Flagged;
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (tileObj.bomb)
            {
                // die
                tileObj.state = (int)TileState.BlewUp;
                tileObj.Invalidate();
                Death();
            }
            else if (tileObj.state == (int)TileState.Clicked)
            {
                return;
            }
            else
            {
                tileObj.state = (int)TileState.Clicked;
                if (tileObj.value == 0) OpenRegion(tileObj.x, tileObj.y);
            }
        }
        tileObj.Invalidate();
    }

    public void OpenRegion(int x, int y)
    {
        Tile tileObj = tileArray[x, y];
        List<Tile> neighbors = tileObj.GetNeighbors();
        gameForm.debugLabel.Text = neighbors.Count.ToString();
        int test = 0;
        for (int i = 0; i < neighbors.Count; i++)
        {
            test++;
            gameForm.debugLabel.Text += " (" + neighbors[i].x.ToString() + ", " + neighbors[i].y.ToString() + ", " + neighbors[i].bomb.ToString() + ")";
            TileClick(neighbors[i].x, neighbors[i].y);
        }
    }

    public void Death()
    {
        gameForm.debugLabel.Text = "died";
        //gameForm.Close();
    }
}
