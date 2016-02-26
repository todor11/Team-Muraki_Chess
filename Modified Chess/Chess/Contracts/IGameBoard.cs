namespace Chess.Contracts
{
    public interface IGameBoard
    {
        ICell[][] Cells { get; }

        ICellManufacturer CellFactory { get; }

        void Init();
    }
}