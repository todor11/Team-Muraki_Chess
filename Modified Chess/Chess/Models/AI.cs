namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Atributes;
    using Chess.Contracts;
    using Chess.Enums;

    public delegate void CompsMoveEventHandler(AI sender, CompsMoveEventArgs args);

    [ArtificialIntelect]
    public class AI : Player, IArtificialIntelect
    {
        public event CompsMoveEventHandler ComputersMove;

        private readonly Dictionary<IPawn, int[][]> allPawnsPosibleMoves;

        private readonly Dictionary<GameDirection, int[][]> posibleCell;

        private readonly Random random;

        public AI(GameColor pawnColor)
           : base(pawnColor)
        {
            this.allPawnsPosibleMoves = new Dictionary<IPawn, int[][]>();
            this.posibleCell = new Dictionary<GameDirection, int[][]>();
            this.random = new Random();
            this.CreatePosibleCellDictionary();
        }

        public IEngine Engine { get; set; }

        public void GetMoveFromTo()
        {
            foreach (var pawn in this.Pawns)
            {
                var matrix = this.GetCellMatrix();
                int row = pawn.Cell.Row;
                int col = pawn.Cell.Col;
                this.GetSinglePawnMovesToEnd(matrix, row, col, pawn.Direction, pawn.IsMoved);
                if (!this.allPawnsPosibleMoves.ContainsKey(pawn))
                {
                    this.allPawnsPosibleMoves[pawn] = new int[matrix.Length][];
                }

                this.allPawnsPosibleMoves[pawn] = matrix;
            }

            var pawnsThatCanFinish = this.GetPawnsThatCanFinish();
            //TODO 
            //TODO 
            //TODO this is only temporary
            int pawnIndexFrom = this.random.Next(0, this.Pawns.Count);
            var cellFrom = this.Pawns[pawnIndexFrom].Cell;
            int cellIndexTo = this.random.Next(0, this.Pawns[pawnIndexFrom].PosibleMoves.Count);
            var cellTo = this.Pawns[pawnIndexFrom].PosibleMoves[cellIndexTo];

            var te = new int[] { cellFrom.Row, cellFrom.Col, cellTo.Row, cellTo.Col };
            if (this.ComputersMove != null)
            {
                this.ComputersMove(this,
                    new CompsMoveEventArgs(new int[] { cellFrom.Row, cellFrom.Col, cellTo.Row, cellTo.Col }));
            }
            this.Engine.MovePawnFromTo(cellFrom, cellTo);
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

        private void GetSinglePawnMovesToEnd(int[][] matrix, int row, int col, GameDirection direction, bool isMoved)
        {
            var queue = new Queue<MatrixCell>();
            queue.Enqueue(new MatrixCell(row, col, 0));
            int[] rows = this.posibleCell[direction][0];
            int[] cols = this.posibleCell[direction][1];
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                if (!isMoved && (currentCell.Row + rows[0] >= 0) && (currentCell.Row + rows[0] < matrix.Length) &&
                    (matrix[currentCell.Row + rows[0]][currentCell.Col + cols[0]] == 0) && 
                    (matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] != -1))
                {
                    queue.Enqueue(new MatrixCell(currentCell.Row + rows[0], currentCell.Col + cols[0], currentCell.Step + 1));
                    matrix[currentCell.Row + rows[0]][currentCell.Col + cols[0]] = currentCell.Step + 1;
                }

                if ((currentCell.Row + rows[1] >= 0) && (currentCell.Row + rows[1] < matrix.Length) &&
                    (matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] == 0))
                {
                    queue.Enqueue(new MatrixCell(currentCell.Row + rows[1], currentCell.Col + cols[1], currentCell.Step + 1));
                    matrix[currentCell.Row + rows[1]][currentCell.Col + cols[1]] = currentCell.Step + 1;
                }

                if ((currentCell.Row + rows[2] >= 0) && (currentCell.Row + rows[2] < matrix.Length) &&
                    (currentCell.Col + cols[2] >= 0) && (currentCell.Col + cols[2] < matrix[currentCell.Row + rows[2]].Length) &&
                    (matrix[currentCell.Row + rows[2]][currentCell.Col + cols[2]] == 0) &&
                    (matrix[currentCell.Row + rows[3]][currentCell.Col + cols[3]] == -1))
                {
                    queue.Enqueue(new MatrixCell(currentCell.Row + rows[2], currentCell.Col + cols[2], currentCell.Step + 1));
                    matrix[currentCell.Row + rows[2]][currentCell.Col + cols[2]] = currentCell.Step + 1;
                }

                if ((currentCell.Row + rows[4] >= 0) && (currentCell.Row + rows[4] < matrix.Length) &&
                    (currentCell.Col + cols[4] >= 0) && (currentCell.Col + cols[4] < matrix[currentCell.Row + rows[4]].Length) &&
                    (matrix[currentCell.Row + rows[4]][currentCell.Col + cols[4]] == 0) &&
                    (matrix[currentCell.Row + rows[5]][currentCell.Col + cols[5]] == -1))
                {
                    queue.Enqueue(new MatrixCell(currentCell.Row + rows[4], currentCell.Col + cols[4], currentCell.Step + 1));
                    matrix[currentCell.Row + rows[4]][currentCell.Col + cols[4]] = currentCell.Step + 1;
                }
            }
        }

        private void CreatePosibleCellDictionary()
        {
            this.posibleCell[GameDirection.Down] = new int[][]
                                                       {
                                                           new int[] { 2, 1, 2, 1, 2, 1},
                                                           new int[] { 0, 0, -2, -1, 2, 1}
                                                       };

        }

        private List<IPawn> GetPawnsThatCanFinish()
        {
            var winnerPawns = new List<IPawn>();
            var direction = this.Pawns[0].Direction;
            
            foreach (var pawnMoveMatrix in this.allPawnsPosibleMoves.Values)
            {
                switch (direction)
                {
                    case GameDirection.Up:
                        

                        break;
                }
            }

            return winnerPawns;
        }
    }

    public class MatrixCell
    {
        public MatrixCell(int row, int col, int step)
        {
            this.Row = row;
            this.Col = col;
            this.Step = step;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Step { get; set; }

    }

    
}
