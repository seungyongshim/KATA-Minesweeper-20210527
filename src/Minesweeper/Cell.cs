using System;

namespace Minesweeper
{
    public class Cell
    {
        public bool IsBomb { get; set; }
        public int NearBombsCount { get; set; }

        public void SetBomb()
        {
            IsBomb = true;
        }

        public override string ToString()
        {
            if (IsBomb is true) return "*";
            return NearBombsCount.ToString();
        }
    }
}