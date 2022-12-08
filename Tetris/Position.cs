using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Position
    {
        public int row { get; set; }
        public int colum { get; set; }

        public Position(int r, int c)
        {
            row = r;
            colum = c;
        }
    }
}
