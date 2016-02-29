namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IGameBoard
    {
        ICell[][] Cells { get; }

        IPawn[] Pawns { get; }

        ICellManufacturer CellFactory { get; }

        IGameFigurePositionsTemplate GameTemplate { get; }

        void Init();

        void UpdatePawnsPosibleCells();
    }
}