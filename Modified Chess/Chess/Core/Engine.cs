namespace Chess.Core
{
    using System;
    using System.Collections.Generic;

    using Chess.Contracts;

    public class Engine : IEngine
    {
        private int gameTurnsCounter;

        public Engine(IGameBoard gameBoard)
        {
            this.GameBoard = gameBoard;
            this.gameTurnsCounter = 0;
        }

        public IGameBoard GameBoard { get; }

        public IFormDesk UserForm { get; set; }

        public Stack<IEnumerable<ICell>> PreviousMoves { get; }

        public IGamePlayer ActivePlayer { get; }

        public IEnumerable<IGamePlayer> Players { get; }

        public int GameTurnsCounter
        {
            get
            {
                return this.gameTurnsCounter;
            }
        }

        public bool IsGameFinished { get; }

        public void Run()
        {
            
            if (this.CheckIsGameFinished())
            {
                //TODO
            }
            else
            {
                this.gameTurnsCounter++;
                //TODO
            }
        }

        public void MovePawnFromTo(ICell from, ICell to)
        {
            //TODO move pawn from cell to cell


            this.Run();
        }

        public void Undo()
        {
            //TODO
        }

        private bool CheckIsGameFinished()
        {
            return false; // TODO
        }
    }
}