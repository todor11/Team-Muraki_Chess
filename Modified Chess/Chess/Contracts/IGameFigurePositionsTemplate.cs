namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IGameFigurePositionsTemplate
    {
        int[][] PawnTemplate { get; }

        int[][] CellTemplate { get; }

        Dictionary<GameColor, GameDirection> PawnDirections { get; }
    }
}
