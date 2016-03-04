namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IGameBoard
    {
        ICell[][] Cells { get; }

        IPawn[] Pawns { get; }

        ICellManufacturer CellFactory { get; }

        IGameTemplate GameTemplate { get; }

        void Init();

        void NotifyPawnsForChanges();
    }
}