namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IGameBoard
    {
        ICell[][] Cells { get; }

        IEnumerable<IPawn> Pawns { get; }

        ICellManufacturer CellFactory { get; }

        IGameFigurePositionsTemplate GameTemplate { get; }

        void Init();
    }
}