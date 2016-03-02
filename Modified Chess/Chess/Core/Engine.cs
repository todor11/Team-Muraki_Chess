namespace Chess.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Contracts;

    public class Engine : IEngine
    {
        private int gameTurnsCounter;

        public Engine(IGameBoard gameBoard)
        {
            this.GameBoard = gameBoard;
            this.gameTurnsCounter = 0;
            this.Players = gameBoard.GameTemplate.Players;
            this.PreviousMoves = new Stack<IEnumerable<ICell>>();
        }

        public IGameBoard GameBoard { get; }

        public IFormDesk UserForm { get; set; }

        public Stack<IEnumerable<ICell>> PreviousMoves { get; }

        public IGamePlayer ActivePlayer { get; private set; }

        public IGamePlayer[] Players { get; }

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
                this.GameBoard.NotifyPawnsForChanges();
                this.UpdateActivePlayer();
                this.ActivePlayer.MakeNextMove();
            }
        }

        public void MovePawnFromTo(ICell from, ICell to)
        {
            var pawn = from.Pawn;
            pawn.Move(to);
            this.PreviousMoves.Push(new ICell[] { from, to });
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

        private void UpdateActivePlayer()
        {
            int currentPlayerIndex = (this.gameTurnsCounter - 1) % this.Players.Length;
            this.ActivePlayer = this.Players[currentPlayerIndex];
        }
    }
}