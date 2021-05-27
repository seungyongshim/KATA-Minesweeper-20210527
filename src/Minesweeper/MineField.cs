using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineField
    {
        public MineField(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new Cell[Width * Height];

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    Cells[i + j * Width] = new Cell();
                }
            }

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
            while(true)
            {
                yield return RandomNumberGenerator.GetInt32(Width * Height);
            }
        }

        
    }
}
