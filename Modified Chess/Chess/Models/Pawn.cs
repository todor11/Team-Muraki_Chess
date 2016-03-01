namespace Chess.Models
{
    using System;
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class Pawn : IPawn
    {
        private ICell cell;

        public Pawn(GameColor color, GameDirection direction)
        {
            this.Color = color;
            this.Direction = direction;
            this.PosibleMoves = new List<ICell>();
            this.IsMoved = false;
        }

        public GameColor Color { get; private set; }

        public bool IsMoved { get; private set; }

        public ICell Cell
        {
            get
            {
                return this.cell;
            }

            set
            {
                //TODO Validate , cell must be in posible moves
                this.cell = value;
            }
        }

        public IEnumerable<ICell> PosibleMoves { get; private set; }

        public GameDirection Direction { get; }

        public void Move(ICell newCell)
        {
            this.IsMoved = true;
            //TODO
        }

        public void UpdatePosibleMoves(int[][] pawnTemplate)
        {
            List<ICell> newPosibleMoves = new List<ICell>();
            switch (this.Direction)
            {
                case GameDirection.Up:
                case GameDirection.Down:  

                    break;
            }

            //TODO
        }
    }
}