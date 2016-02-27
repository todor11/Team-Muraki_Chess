namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IGameFigurePositionsTemplate
    {
        int[][] PawnColorTemplate { get; }

        int[][] CellColorTemplate { get; }
    }
}
