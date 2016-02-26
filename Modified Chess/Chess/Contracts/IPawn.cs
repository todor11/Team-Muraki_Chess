namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IPawn
    {
        GameColor Color { get; set; }

        bool IsMoved { get; set; }

        ICell Cell { get; set; }
        
        IEnumerable<ICell> PosibleMoves { get; }

        void Move(ICell newCell);
    }
}