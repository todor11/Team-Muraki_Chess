namespace Chess.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Chess.Contracts;
    using Chess.Enums;
    using Chess.Atributes;
    using Chess.Utilities;

    public class Engine : IEngine
    {
        public event EndGameEventHandler GameOverHandler;

        private bool isGameFinished;

        private int gameTurnsCounter;

        public Engine(IGameBoard gameBoard)
        {
            this.GameBoard = gameBoard;
            this.gameTurnsCounter = 0;
            this.Players = gameBoard.GameTemplate.Players;
            this.PreviousMoves = new Stack<IEnumerable<ICell>>();
            this.isGameFinished = false;
            this.SetThisEngineToAiIfExist();
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

        public bool IsGameFinished
        {
            get
            {
                return this.isGameFinished;
            }

            private set
            {
                if (value)
                {
                    if (this.GameOverHandler != null)
                    {
                        this.GameOverHandler(this, new EndGameEventArguments(this.isGameFinished, this.ActivePlayer.Name));
                    }
                    this.isGameFinished = value;
                }
            }
        }

        public void Run()
        {
            
            if (this.CheckIsGameFinished())
            {
                this.IsGameFinished = true;
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
            //check first row
            int firstRowLenght = this.GameBoard.Cells[0].Length;
            for (int i = 0; i < firstRowLenght; i++)
            {
                if (!this.GameBoard.Cells[0][i].IsFree && this.GameBoard.Cells[0][i].Pawn.Direction == GameDirection.Up)
                {
                    this.IsGameFinished = true;
                    return true;
                }
            }

            //check last row
            int maxRowIndex = this.GameBoard.Cells.Length - 1;
            int lastRowLenght = this.GameBoard.Cells[maxRowIndex].Length;
            for (int i = 0; i < lastRowLenght; i++)
            {
                if (!this.GameBoard.Cells[maxRowIndex][i].IsFree && this.GameBoard.Cells[maxRowIndex][i].Pawn.Direction == GameDirection.Down)
                {
                    this.IsGameFinished = true;
                    return true;
                }
            }

            //check first col
            for (int i = 1; i < maxRowIndex; i++)
            {
                if (!this.GameBoard.Cells[i][0].IsFree && this.GameBoard.Cells[i][0].Pawn.Direction == GameDirection.Left)
                {
                    this.IsGameFinished = true;
                    return true;
                }
            }

            //check last col
            for (int i = 1; i < maxRowIndex; i++)
            {
                if (!this.GameBoard.Cells[i][this.GameBoard.Cells[i].Length - 1].IsFree && 
                    this.GameBoard.Cells[i][this.GameBoard.Cells[i].Length - 1].Pawn.Direction == GameDirection.Right)
                {
                    this.IsGameFinished = true;
                    return true;
                }
            }

            return false;
        }

        private void UpdateActivePlayer()
        {
            int currentPlayerIndex = (this.gameTurnsCounter - 1) % this.Players.Length;
            this.ActivePlayer = this.Players[currentPlayerIndex];
        }

        private void SetThisEngineToAiIfExist()
        {
            var itemTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.CustomAttributes
                    .Any(a => a.AttributeType == typeof(ArtificialIntelectAttribute)))
                    .ToArray();
            
            foreach (var player in this.GameBoard.GameTemplate.Players)
            {
                if (itemTypes.Contains(player.GetType()))
                {
                    var artificialIntelect = player as IArtificialIntelect;
                    artificialIntelect.Engine = this;
                }
            }
        }
    }
}