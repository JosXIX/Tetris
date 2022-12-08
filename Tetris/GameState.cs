using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.TextFormatting;
using System.Diagnostics.CodeAnalysis;

namespace Tetris
{
    public class GameState
    {
        private Block? fallingBlock;

        public Block FallingBlock
        {
#pragma warning disable CS8603 // Mögliche Nullverweisrückgabe.
            get => fallingBlock;
#pragma warning restore CS8603 // Mögliche Nullverweisrückgabe.
            private set
            {
                fallingBlock = value;
                fallingBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    fallingBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        fallingBlock.Move(-1, 0);
                    }
                }
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public Block? StorageBlock { get; private set; }
        public bool CanHold { get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            FallingBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        public bool BlockFits()
        {
            foreach (Position p in FallingBlock.TilePosition())
            {
                if (!GameGrid.IsEmpty(p.row, p.colum))
                {
                    return false;
                }
            }
            return true;
        }

        public void StoreBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if (StorageBlock != null)
            {
                Block tmp = FallingBlock;
                FallingBlock = StorageBlock;
                StorageBlock = tmp;
            }
            else
            {
                StorageBlock = FallingBlock;
                FallingBlock = BlockQueue.GetAndUpdate();
            }
            CanHold = false;
        }

        public void RotateBlockCW()
        {
            FallingBlock.RotateCW();

            if (!BlockFits())
            {
                FallingBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            FallingBlock.RotateCCW();

            if (!BlockFits())
            {
                FallingBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            FallingBlock.Move(0, -1);

            if (!BlockFits())
            {
                FallingBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            FallingBlock.Move(0, 1);

            if (!BlockFits())
            {
                FallingBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (Position p in FallingBlock.TilePosition())
            {
                GameGrid[p.row, p.colum] = FallingBlock.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                FallingBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        public void MoveBlockDown()
        {
            FallingBlock.Move(1, 0);

            if (!BlockFits())
            {
                FallingBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsRowEmptyBlockDrop(p.row + drop + 1, p.colum))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.row;

            foreach (Position p in FallingBlock.TilePosition())
            {
                drop = Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        public void DropBlock()
        {
            FallingBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
