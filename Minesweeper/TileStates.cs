using System;

namespace Minesweeper
{
    public enum TileState
    {
        Empty = 0,
        // Stupid; Use tile.bomb instead
        Mine = 1,
        Flagged = 2,
        Question = 3,
        Clicked = 4
    }
}