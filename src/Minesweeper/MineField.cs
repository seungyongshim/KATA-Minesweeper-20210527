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
                     select new Cell())
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

        public void CalculatedNearBombsCount() => throw new System.NotImplementedException();
    }
}
