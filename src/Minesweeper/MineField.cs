using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Minesweeper
{
    public class MineField
    {
        public MineField(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = (from y in Enumerable.Range(0, Height)
                     from x in Enumerable.Range(0, Width)
                     select new Cell((x,y)))
                    .ToList();
        }

        public IList<Cell> Cells { get; set; }

        public int Width { get; }
        public int Height { get; }

        public void GenerateBombs(int countBombs)
        {
            foreach (var idx in (from idx in RandomGenerator()
                                 select idx).Distinct().Take(countBombs))
            {
                Cells[idx].SetBomb();
            }
        }

        public IEnumerable<int> RandomGenerator()
        {
            while (true)
            {
                yield return RandomNumberGenerator.GetInt32(Width * Height);
            }
        }

        public void CalculatedNearBombsCount()
        {
            foreach(var cell in from cell in Cells
                                where cell.IsBomb
                                select cell)
            {
                foreach(var nearcell in NearCellGenerator(cell))
                {
                    nearcell.NearBombsCount++;
                }
            }
        }

        private IEnumerable<Cell> NearCellGenerator(Cell cell)
        {
            var (x, y) = cell.XY;

            return InternalNearCellCenerator().Where(x => x is not null);

            IEnumerable<Cell> InternalNearCellCenerator()
            {
                yield return GetCell(x - 1, y - 1);
                yield return GetCell(x, y - 1);
                yield return GetCell(x + 1, y - 1);
                yield return GetCell(x - 1, y);
                yield return GetCell(x + 1, y);
                yield return GetCell(x - 1, y + 1);
                yield return GetCell(x, y + 1);
                yield return GetCell(x + 1, y + 1);
            }
        }

        public void Click(int v1, int v2) => throw new System.NotImplementedException();
        private Cell GetCell(int x, int y) => (x, y) switch
        {
            (var a, _) when a < 0 => null,
            (var a, _) when a >= Width => null,
            (_, var b) when b < 0 => null,
            (_, var b) when b >= Height => null,
            (var a, var b) => Cells[a + b * Width],
        };
    }
}
