using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.row, StartOffset.colum);
        }

        public IEnumerable<Position> TilePosition()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.row + offset.row, p.colum + offset.colum);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int r, int c)
        {
            offset.row += r;
            offset.colum += c;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.row = StartOffset.row;
            offset.colum = StartOffset.colum;
        }
    }
}
