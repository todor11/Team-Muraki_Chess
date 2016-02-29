namespace Chess.Models
{
    using System;
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class Pawn : IPawn
    {
        private ICell cell;

        public Pawn(GameColor color)
        {
            this.Color = color;
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
                this.UpdatePosibleMoves();
            }
        }

        public IEnumerable<ICell> PosibleMoves { get; private set; }

        public void Move(ICell newCell)
        {
            this.IsMoved = true;
            //TODO
        }

        private void UpdatePosibleMoves()
        {
            //TODO
        }
        
    }
}