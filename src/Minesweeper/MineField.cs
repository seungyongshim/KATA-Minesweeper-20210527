using System;
using System.Collections.Generic;
using System.Linq;
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

        public void GenerateBombs(int v) => throw new NotImplementedException();

        public int Width { get; }
        public int Height { get; }
    }
}
