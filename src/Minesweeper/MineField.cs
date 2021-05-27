using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineField
    {
        private int v1;
        private int v2;

        public MineField(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public IList<Cell> Cells { get; set; }
    }
}
