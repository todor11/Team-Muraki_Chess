namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Chess.Atributes;
    using Chess.Contracts;
    using Chess.Enums;

    public delegate void CompsMoveEventHandler(AI sender, CompsMoveEventArgs args);

    [ArtificialIntelect]
    public class AI : Player, IArtificialIntelect
    {
        public event CompsMoveEventHandler ComputersMove;

        private readonly Dictionary<IPawn, IMatrixCell> winningPawns;

        private readonly Dictionary<GameDirection, int[][]> posibleCell;

        private readonly Random random;

        public AI(GameColor pawnColor)
           : base(pawnColor)
        {
            this.posibleCell = new Dictionary<GameDirection, int[][]>();
            this.winningPawns = new Dictionary<IPawn, IMatrixCell>();
            this.random = new Random();
            this.CreatePosibleCellDictionary();
        }

        public IEngine Engine { get; set; }

        public void GetMoveFromTo()
        {
            foreach (var pawn in this.Pawns)
            {
                int row = pawn.Cell.Row;
                int col = pawn.Cell.Col;
                var winningPawnProperties = this.GetSinglePawnMovesToEnd(row, col, pawn.Direction, pawn.IsMoved);
                if (winningPawnProperties.Row != -1)
                {
                    this.winningPawns[pawn] = winningPawnProperties;
                }
            }

            if (this.winningPawns.Count > 0)
            {
                int minStep = Int32.MaxValue;
                IPawn winner = this.Pawns[0];
                foreach (var pawn in this.winningPawns.Keys)
                {
                    if (this.winningPawns[pawn].Step < minStep)
                    {
                        minStep = this.winningPawns[pawn].Step;
                        winner = pawn;
                    }
                }

                ICell winningCellFrom = winner.Cell;
                int cellToRow = this.winningPawns[winner]
                    .RoadToFinal.ToString()
                    .Split(';')
                    .ToArray()[1]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray()[0];
                int cellToCol = this.winningPawns[winner]
                    .RoadToFinal.ToString()
                    .Split(';')
                    .ToArray()[1]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray()[1];
                ICell winningCellTo = this.Engine.GameBoard.Cells[cellToRow][cellToCol];
                this.winningPawns.Clear();

                if (this.ComputersMove != null)
                {
                    this.ComputersMove(this,
                        new CompsMoveEventArgs(new int[] { winningCellFrom.Row, winningCellFrom.Col, cellToRow, cellToCol }));
                }

                this.Engine.MovePawnFromTo(winningCellFrom, winningCellTo);
            }
            else
            {
                var pawnsWhoHasPosibleMoves = this.Pawns.Where(p => p.PosibleMoves.Count > 0).ToArray();
                int pawnIndexFrom = this.random.Next(0, pawnsWhoHasPosibleMoves.Length);
                ICell cellFrom = pawnsWhoHasPosibleMoves[pawnIndexFrom].Cell;
                int cellIndexTo = this.random.Next(0, pawnsWhoHasPosibleMoves[pawnIndexFrom].PosibleMoves.Count);
                ICell cellTo = pawnsWhoHasPosibleMoves[pawnIndexFrom].PosibleMoves[cellIndexTo];

                if (this.ComputersMove != null)
                {
                    this.ComputersMove(this,
                        new CompsMoveEventArgs(new int[] { cellFrom.Row, cellFrom.Col, cellTo.Row, cellTo.Col }));
                }

                this.Engine.MovePawnFromTo(cellFrom, cellTo);
            }
        }

        public override void MakeNextMove()
        {
            this.GetMoveFromTo();
        }

        private int[][] GetCellMatrix()
        {
            int rows = this.Engine.GameBoard.Cells.Length;
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cols = this.Engine.GameBoard.Cells[i].Length;
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    if (!this.Engine.GameBoard.Cells[i][j].IsFree)
                    {
                        matrix[i][j] = -1;
                    }
                }
            }

            return matrix;
        }

        private IMatrixCell GetSinglePawnMovesToEnd(int row, int col, GameDirection direction, bool isMoved)
        {
            var matrix = this.GetCellMatrix();
            var queue = new Queue<MatrixCell>();
            bool tempIsMoved = isMoved;
            queue.Enqueue(new MatrixCell(row, col, 0, string.Empty));
            int[] rows = this.posibleCell[direction][0];
            int[] cols = this.posibleCell[direction][1];
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                if ((currentCell.Row + rows[2] >= 0) && (currentCell.Row + rows[2] < matrix.Length) &&
                    (currentCell.Col + cols[2] >= 0) && (currentCell.Col + cols[2] < matrix[currentCell.Row + rows[2]].Length) &&
                    (matrix[currentCell.Row + rows[2]][currentCell.Col + cols[2]] == 0) &&
                    (matrix[currentCell.Row + rows[3]][currentCell.Col + cols[3]] == -1))
                {
                    var newMatrixCell = new MatrixCell(
                        currentCell.Row + rows[2],
                        currentCell.Col + cols[2],
                        currentCell.Step + 1,
                        currentCell.RoadToFinal);
                    if (this.ValidateIsOnFinal(currentCell.Row + rows[2], currentCell.Col + cols[2], direction))
                    {
                        return newMatrixCell;
                    }

                    queue.Enqueue(newMatrixCell);
                    matrix[currentCell.Row + rows[2]][currentCell.Col + cols[2]] = currentCell.Step + 1;
                }

                if ((currentCell.Row + rows[4] >= 0) && (currentCell.Row + rows[4] < matrix.Length) &&
                    (currentCell.Col + cols[4] >= 0) && (currentCell.Col + cols[4] < matrix[currentCell.Row + rows[4]].Length) &&
                    (matrix[currentCell.Row + rows[4]][currentCell.Col + cols[4]] == 0) &&
                    (matrix[currentCell.Row + rows[5]][currentCell.Col + cols[5]] == -1))
                {
                    var newMatrixCell = new MatrixCell(
                        currentCell.Row + rows[4],
                        currentCell.Col + cols[4],
                        currentCell.Step + 1,
                        currentCell.RoadToFinal);
                    if (this.ValidateIsOnFinal(currentCell.Row + rows[4], currentCell.Col + cols[4], direction))
                    {
                        return newMatrixCell;
                    }

                    queue.Enqueue(newMatrixCell);
                    matrix[currentCell.Row + rows[4]][currentCell.Col + cols[4]] = currentCell.Step + 1;
                }

                if (!tempIsMoved && (currentCell.Row + rows[0] >= 0) && (currentCell.Row + rows[0] < matrix.Length) &&
                    (matrix[currentCell.Row + rows[0]][currentCell.Col + cols[0]] == 0) && 
                    (matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] != -1))
                {
                    var newMatrixCell = new MatrixCell(
                        currentCell.Row + rows[0],
                        currentCell.Col + cols[0],
                        currentCell.Step + 1,
                        currentCell.RoadToFinal);
                    if (this.ValidateIsOnFinal(currentCell.Row + rows[0], currentCell.Col + cols[0], direction))
                    {
                        return newMatrixCell;
                    }

                    tempIsMoved = true;
                    queue.Enqueue(newMatrixCell);
                    matrix[currentCell.Row + rows[0]][currentCell.Col + cols[0]] = currentCell.Step + 1;
                }

                if ((currentCell.Row + rows[1] >= 0) && (currentCell.Row + rows[1] < matrix.Length) &&
                    (matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] == 0))
                {
                    var newMatrixCell = new MatrixCell(
                        currentCell.Row + rows[1],
                        currentCell.Col + cols[1],
                        currentCell.Step + 1,
                        currentCell.RoadToFinal);
                    if (this.ValidateIsOnFinal(currentCell.Row + rows[1], currentCell.Col + cols[1], direction))
                    {
                        return newMatrixCell;
                    }

                    queue.Enqueue(newMatrixCell);
                    matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] = currentCell.Step + 1;
                }
            }

            return new MatrixCell(-1, -1, 0, String.Empty);
        }

        private bool ValidateIsOnFinal(int row, int col, GameDirection direction)
        {
            switch (direction)
            {
                case GameDirection.Up:
                    if (row == 0)
                    {
                        return true;
                    }
                    break;
                case GameDirection.Down:
                    if (row == this.Engine.GameBoard.Cells.Length - 1)
                    {
                        return true;
                    }
                    break;
                case GameDirection.Left:
                    if (col == 0)
                    {
                        return true;
                    }
                    break;
                case GameDirection.Right:
                    if (col == this.Engine.GameBoard.Cells[row].Length - 1)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private void CreatePosibleCellDictionary()
        {
            this.posibleCell[GameDirection.Down] = new int[][]
                                                       {
                                                           new int[] { 2, 1, 2, 1, 2, 1},
                                                           new int[] { 0, 0, -2, -1, 2, 1}
                                                       };
            //TODO
        }
    }
}
