namespace Chess.Models
{
    using Contracts;
    using Enums;

    public class Cell : ICell
    {
        public Cell(int row, int col, GameColor cellColor, IPawn pawn)
        {
            this.Row = row;
            this.Col = col;
            this.CellColor = cellColor;
            this.Pawn = pawn;
            this.Pawn.Cell = this;
            this.IsFree = false;
        }

        public Cell(int row, int col, GameColor cellColor)
        {
            this.Row = row;
            this.Col = col;
            this.CellColor = cellColor;
            this.IsFree = true;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool IsFree { get; set; }

        public IPawn Pawn { get; set; }

        public GameColor CellColor { get; set; }
    }
}