namespace Chess.Models
{
    using Chess.Contracts;

    public class GameResult : IGameResult
    {
        public GameResult(string userName, int numberOfMoves)
        {
            this.UserName = userName;
            this.NumberOfMoves = numberOfMoves;
        }

        public string UserName { get; set; }

        public int NumberOfMoves { get; set; }

        public override string ToString()
        {
            return $"{this.UserName} - {this.NumberOfMoves}";
        }
    }
}
