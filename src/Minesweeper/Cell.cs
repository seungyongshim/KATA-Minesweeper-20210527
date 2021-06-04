using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Cell
    {
        public Cell() : this((0,0), Enumerable.Empty<Cell>())
        {

        }

        public Cell((int x, int y) p, IEnumerable<Cell> enumerable)
        {
            XY = p;
            NearCellGenerator = enumerable;
        }

        public bool IsBomb { get; set; }
        public int NearBombsCount { get; set; }
        public bool IsCover { get; private set; } = true;
        public (int x, int y) XY { get; }
        public IEnumerable<Cell> NearCellGenerator { get; }

        public void SetBomb()
        {
            IsBomb = true;
        }

        public void Click()
        {
            if (IsCover is not true) return;

            IsCover = false;

            if (NearBombsCount == 0)
            {
                foreach (var nearcell in NearCellGenerator)
                {
                    nearcell.Click();
                }
            }
        }

        public override string ToString() => (IsCover, IsBomb, NearBombsCount) switch
        {
            (true, _, _) => ".",
            (false, true, _) => "*",
            (false, false, var m) => m.ToString()
        };
    }
}
