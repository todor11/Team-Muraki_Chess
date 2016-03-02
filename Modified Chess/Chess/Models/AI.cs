namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Atributes;
    using Chess.Contracts;
    using Chess.Enums;

    [ArtificialIntelect]
    public class AI : Player, IArtificialIntelect
    {
        public AI(GameColor pawnColor)
           : base(pawnColor)
        {
        }

        public IEngine Engine { get; }

        public void GetMoveFromTo()
        {
            foreach (var realPawn in this.Pawns)
            {
                var virtualPawn = this.CreateVirtualPawn(realPawn);
                var matrix = this.GetCellMatrix();
                virtualPawn.UpdatePosibleMoves(this.Engine.GameBoard.Cells);
            }
        }

        public override void MakeNextMove()
        {
            this.GetMoveFromTo();
        }

        private char[][] GetCellMatrix()
        {
            int rows = this.Engine.GameBoard.Cells.Length;
            char[][] matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cols = this.Engine.GameBoard.Cells[i].Length;
                for (int j = 0; j < cols; j++)
                {
                    if (!this.Engine.GameBoard.Cells[i][j].IsFree)
                    {
                        matrix[i][j] = 'X';
                    }
                }
            }

            return matrix;
        }

        private IPawn CreateVirtualPawn(IPawn realPawn)
        {
            var cell =
                this.Engine.GameBoard.CellFactory.ManufactureCell(
                    realPawn.Cell.Row,
                    realPawn.Cell.Col,
                    realPawn.Color,
                    realPawn.Color,
                    realPawn.Direction);

            return cell.Pawn;
        }
    }
}
