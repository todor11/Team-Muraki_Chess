namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Utilities;

    public delegate void EndGameEventHandler(IEngine sender, EndGameEventArguments args);

    public interface IEngine
    {
        event EndGameEventHandler GameOverHandler;

        IGameBoard GameBoard { get; }

        IFormDesk UserForm { get; set; }

        Stack<IEnumerable<ICell>> PreviousMoves { get; }

        IGamePlayer ActivePlayer { get; }

        IGamePlayer[] Players { get; }

        int GameTurnsCounter { get; }

        bool IsGameFinished { get; }

        void Run();

        void MovePawnFromTo(ICell from, ICell to);

        void Undo();
    }
}