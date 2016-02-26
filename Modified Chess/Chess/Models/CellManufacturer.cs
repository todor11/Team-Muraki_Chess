namespace Chess.Models
{
    using Chess.Contracts;
    using Chess.Enums;

    public class CellManufacturer : ICellManufacturer
    {
        public CellManufacturer(IPawnManufacturer pawnManufacturer)
        {
            this.PawnManufacturer = pawnManufacturer;
        }

        public IPawnManufacturer PawnManufacturer { get; private set; }

        public ICell ManufactureCell(int row, int col, GameColor cellColor, GameColor pawnColor)
        {
            var currentPawn = this.PawnManufacturer.ManufacturePawn(pawnColor);
            return new Cell(row, col, cellColor, currentPawn);
        }

        public ICell ManufactureCell(int row, int col, GameColor cellColor)
        {
            return new Cell(row, col, cellColor);
        }
    }
}
