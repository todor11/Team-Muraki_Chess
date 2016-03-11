namespace Chess.Models
{
    using Contracts;
    using Enums;

    public class CellManufacturer : ICellManufacturer
    {
        public CellManufacturer(IPawnManufacturer pawnManufacturer)
        {
            this.PawnManufacturer = pawnManufacturer;
        }

        public IPawnManufacturer PawnManufacturer { get; private set; }

        public ICell ManufactureCell(int row, int col, GameColor cellColor, GameColor pawnColor, GameDirection direction)
        {
            var currentPawn = this.PawnManufacturer.ManufacturePawn(pawnColor, direction);
            return new Cell(row, col, cellColor, currentPawn);
        }

        public ICell ManufactureCell(int row, int col, GameColor cellColor)
        {
            return new Cell(row, col, cellColor);
        }
    }
}
