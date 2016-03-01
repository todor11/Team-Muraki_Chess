namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Contracts;
    using Chess.Enums;

    public class Pawn : IPawn
    {
        private ICell cell;

        public Pawn(GameColor color, GameDirection direction)
        {
            this.Color = color;
            this.Direction = direction;
            this.PosibleMoves = new List<ICell>();
            this.IsMoved = false;
        }

        public GameColor Color { get; private set; }

        public bool IsMoved { get; private set; }

        public ICell Cell
        {
            get
            {
                return this.cell;
            }

            set
            {
                this.cell = value;
            }
        }

        public IEnumerable<ICell> PosibleMoves { get; private set; }

        public GameDirection Direction { get; }

        public void Move(ICell newCell)
        {
            if (newCell.IsFree && this.PosibleMoves.Contains(newCell))
            {
                this.IsMoved = true;
                this.Cell.IsFree = true;
                newCell.IsFree = false;
                this.Cell = newCell;
            }
        }

        public void UpdatePosibleMoves(ICell[][] allCells)
        {
            List<ICell> newPosibleMoves = new List<ICell>();
            int currentRow = this.Cell.Row;
            int currentCol = this.Cell.Col;
            switch (this.Direction)
            {
                case GameDirection.Up:
                case GameDirection.Down:
                    if ((currentRow + (int)this.Direction >= 0) && 
                        (currentRow + (int)this.Direction < allCells.Length) && 
                        allCells[currentRow + (int)this.Direction][currentCol].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow + (int)this.Direction][currentCol]);
                        if ((!this.IsMoved) && (currentRow + (int)this.Direction + (int)this.Direction >= 0) &&
                            (currentRow + (int)this.Direction + (int)this.Direction < allCells.Length) && 
                            allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol].IsFree)
                        {
                            newPosibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol]);
                        }
                    }

                    if ((currentCol - 2 >= 0) && (currentCol - 2 < allCells[currentRow + (int)this.Direction + (int)this.Direction].Length) &&
                        allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol - 2].IsFree &&
                        (currentCol - 1 >= 0) && (currentCol - 1 < allCells[currentRow + (int)this.Direction].Length) &&
                        !allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol - 1].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol - 2]);
                    }

                    if ((currentCol + 2 >= 0) && (currentCol + 2 < allCells[currentRow + (int)this.Direction + (int)this.Direction].Length) &&
                        allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol + 2].IsFree &&
                        (currentCol + 1 >= 0) && (currentCol + 1 < allCells[currentRow + (int)this.Direction].Length) &&
                        !allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol + 1].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol + 2]);
                    }
                    break;

                case GameDirection.Left:
                case GameDirection.Right:
                    int direction = (int)this.Direction % 10;
                    if ((currentCol + direction >= 0) &&
                        (currentCol + direction < allCells[currentRow].Length) &&
                        allCells[currentRow][currentCol + direction].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow][currentCol + direction]);
                        if ((!this.IsMoved) && (currentCol + direction + direction >= 0) &&
                            (currentCol + direction + direction < allCells[currentRow].Length) &&
                            allCells[currentRow][currentCol + direction + direction].IsFree)
                        {
                            newPosibleMoves.Add(allCells[currentRow][currentCol + direction + direction]);
                        }
                    }

                    if ((currentRow - 2 >= 0) && (currentRow - 2 < allCells.Length) &&
                        allCells[currentRow - 2][currentCol + direction + direction].IsFree &&
                        (currentRow - 1 >= 0) && (currentRow - 1 < allCells.Length) &&
                        !allCells[currentRow - 1][currentCol + direction].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow - 2][currentCol + direction + direction]);
                    }

                    if ((currentRow + 2 >= 0) && (currentRow + 2 < allCells.Length) &&
                        allCells[currentRow + 2][currentCol + direction + direction].IsFree &&
                        (currentRow + 1 >= 0) && (currentRow + 1 < allCells.Length) &&
                        !allCells[currentRow + 1][currentCol + direction].IsFree)
                    {
                        newPosibleMoves.Add(allCells[currentRow + 2][currentCol + direction + direction]);
                    }
                    break;
            }

            this.PosibleMoves = newPosibleMoves;
        }
    }
}