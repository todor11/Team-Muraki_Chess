namespace Chess.Core
{
    using System;
    using System.Collections.Generic;

    using Chess.Contracts;

    public class Engine : IEngine
    {
        public Engine(IGameBoard gameBoard)
        {
            this.GameBoard = gameBoard;
        }

        public IGameBoard GameBoard { get; set; }

        public IFormDesk UserForm { get; set; }

        public IEnumerable<string> PreviousMoves { get; set; }

        public bool ActivePlayer { get; set; }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}