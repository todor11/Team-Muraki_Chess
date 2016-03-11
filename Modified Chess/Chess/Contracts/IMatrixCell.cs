namespace Chess.Contracts
{
    public interface IMatrixCell
    {
        int Row { get; set; }

        int Col { get; set; }

        int Step { get; set; }

        string RoadToFinal { get; set; }
    }
}
