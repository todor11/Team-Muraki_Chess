namespace Chess.Contracts
{
    using System.Text;
    
    public interface IMatrixCell
    {
        int Row { get; set; }

        int Col { get; set; }

        int Step { get; set; }

        string RoadToFinal { get; set; }
    }
}
