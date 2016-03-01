namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IEngine
    {
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