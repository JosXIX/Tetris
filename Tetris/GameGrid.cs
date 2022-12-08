using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int row { get; }
        public int colum { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int r, int c)
        {
            row = r;
            colum = c;
            grid = new int[r, c];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < row && c >= 0 && c < colum;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for (int c = 0; c < colum; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int r)
        {
            try
            {
                for (int c = 0; c < colum; c++)
                {
                    if (grid[r, c] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (System.IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsRowEmptyBlockDrop(int r, int c)
        {
            try
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
                return true;
            }
            catch (System.IndexOutOfRangeException)
            {
                return false;
            }
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < colum; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < colum; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = row-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
