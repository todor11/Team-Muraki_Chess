namespace Chess.Contracts
{
    using Chess.Enums;

    public interface ICell
    {
        int Row { get; set; }

        int Col { get; set; }

        bool IsFree { get; set; }

        IPawn Pawn { get; set; }

        GameColor CellColor { get; set; }
    }
}