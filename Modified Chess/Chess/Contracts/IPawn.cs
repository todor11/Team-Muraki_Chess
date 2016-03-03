namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IPawn
    {
        GameColor Color { get; }

        bool IsMoved { get; }

        ICell Cell { get; set; }
        
        IList<ICell> PosibleMoves { get; }

        GameDirection Direction { get; }

        void Move(ICell newCell);

        void UpdatePosibleMoves(ICell[][] allCells);
    }
}