namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Contracts;
    using Chess.Enums;

    public class Pawn : IPawn
    {
        private readonly IList<ICell> posibleMoves;

        private ICell cell;

        public Pawn(GameColor color, GameDirection direction)
        {
            this.Color = color;
            this.Direction = direction;
            this.posibleMoves = new List<ICell>();
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

        public IList<ICell> PosibleMoves
        {
            get
            {
                return this.posibleMoves;
            }
        }

        public GameDirection Direction { get; }

        public void Move(ICell newCell)
        {
            if (newCell.IsFree && this.posibleMoves.Contains(newCell))
            {
                this.IsMoved = true;
                this.Cell.IsFree = true;
                newCell.IsFree = false;
                newCell.Pawn = this;
                this.Cell = newCell;
            }
        }

        public void UpdatePosibleMoves(ICell[][] allCells)
        {
            this.posibleMoves.Clear();
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
                        this.posibleMoves.Add(allCells[currentRow + (int)this.Direction][currentCol]);
                        if ((!this.IsMoved) && (currentRow + (int)this.Direction + (int)this.Direction >= 0) &&
                            (currentRow + (int)this.Direction + (int)this.Direction < allCells.Length) && 
                            allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol].IsFree)
                        {
                            this.posibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol]);
                        }
                    }

                    if ((currentCol - 2 >= 0) && (currentRow + (int)this.Direction + (int)this.Direction >= 0) &&
                        (currentRow + (int)this.Direction + (int)this.Direction < allCells.Length) &&
                        allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol - 2].IsFree &&
                        !allCells[currentRow + (int)this.Direction][currentCol - 1].IsFree)
                    {
                        this.posibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol - 2]);
                    }

                    if ((currentRow + (int)this.Direction + (int)this.Direction >= 0) && 
                        (currentRow + (int)this.Direction + (int)this.Direction < allCells.Length) &&
                        (currentCol + 2 < allCells[currentRow + (int)this.Direction + (int)this.Direction].Length) &&
                        allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol + 2].IsFree &&
                        !allCells[currentRow + (int)this.Direction][currentCol + 1].IsFree)
                    {
                        this.posibleMoves.Add(allCells[currentRow + (int)this.Direction + (int)this.Direction][currentCol + 2]);
                    }
                    break;

                case GameDirection.Left:
                case GameDirection.Right:
                    int direction = (int)this.Direction % 10;
                    if ((currentCol + direction >= 0) &&
                        (currentCol + direction < allCells[currentRow].Length) &&
                        allCells[currentRow][currentCol + direction].IsFree)
                    {
                        this.posibleMoves.Add(allCells[currentRow][currentCol + direction]);
                        if ((!this.IsMoved) && (currentCol + direction + direction >= 0) &&
                            (currentCol + direction + direction < allCells[currentRow].Length) &&
                            allCells[currentRow][currentCol + direction + direction].IsFree)
                        {
                            this.posibleMoves.Add(allCells[currentRow][currentCol + direction + direction]);
                        }
                    }

                    if ((currentRow - 2 >= 0) && (currentCol + direction + direction >= 0) &&
                        (currentCol + direction + direction < allCells[currentRow - 2].Length) &&
                        allCells[currentRow - 2][currentCol + direction + direction].IsFree &&
                        !allCells[currentRow - 1][currentCol + direction].IsFree)
                    {
                        this.posibleMoves.Add(allCells[currentRow - 2][currentCol + direction + direction]);
                    }

                    if ((currentRow + 2 < allCells.Length) && (currentCol + direction + direction >= 0) &&
                        (currentCol + direction + direction < allCells[currentRow + 2].Length) &&
                        allCells[currentRow + 2][currentCol + direction + direction].IsFree &&
                        !allCells[currentRow + 1][currentCol + direction].IsFree)
                    {
                        this.posibleMoves.Add(allCells[currentRow + 2][currentCol + direction + direction]);
                    }
                    break;
            }
        }
    }
}