using System;

namespace Minesweeper
{
    public class Cell
    {
        public Cell() : this((0,0))
        {

        }

        public Cell((int x, int y) p)
        {
            XY = p;
        }

        public bool IsBomb { get; set; }
        public int NearBombsCount { get; set; }
        public bool IsCover { get; private set; } = true;
        public (int x, int y) XY { get; }

        public void SetBomb()
        {
            IsBomb = true;
        }

        public void Click()
        {
            IsCover = false;
        }

        public override string ToString() => (IsCover, IsBomb, NearBombsCount) switch
        {
            (true, _, _) => ".",
            (false, true, _) => "*",
            (false, false, var m) => m.ToString()
        };
    }
}
