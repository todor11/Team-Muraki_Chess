namespace Chess.Contracts
{
    public interface IGameResult
    {
        string UserName { get; set; }

        int NumberOfMoves { get; set; }
    }
}