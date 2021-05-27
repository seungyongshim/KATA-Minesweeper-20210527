using System;

namespace Minesweeper
{
    public class Cell
    {
        public bool IsBomb { get; set; }
        public int NearBombsCount { get; set; }
        public bool IsCover { get; private set; } = true;

        public void SetBomb()
        {
            IsBomb = true;
        }

        public override string ToString()
        {
            if (IsCover is true) return ".";
            if (IsBomb is true) return "*";
            return NearBombsCount.ToString();
        }
    }
}
