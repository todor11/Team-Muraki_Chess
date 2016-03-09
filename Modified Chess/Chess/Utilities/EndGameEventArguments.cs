namespace Chess.Utilities
{
    using System;

    public class EndGameEventArguments : EventArgs
    {
        public EndGameEventArguments(bool isGameEnded, string winnerName)
        {
            this.IsGameEnded = isGameEnded;
            this.WinnerName = winnerName;
        }

        public bool IsGameEnded { get; set; }

        public string WinnerName { get; set; }
    }
}
