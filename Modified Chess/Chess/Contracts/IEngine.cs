namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IEngine
    {
        IGameBoard GameBoard { get; }

        IFormDesk UserForm { get; set; }

        IEnumerable<string> PreviousMoves { get; }

        bool ActivePlayer { get; set; }

        void Undo();
    }
}