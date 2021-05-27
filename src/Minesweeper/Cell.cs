using System;

namespace Minesweeper
{
    public class Cell
    {
        public object IsBomb { get; set; }

        public void SetBomb() => throw new NotImplementedException();
    }
}
