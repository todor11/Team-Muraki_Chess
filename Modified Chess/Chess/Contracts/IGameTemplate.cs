namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Enums;

    public interface IGameTemplate
    {
        int[][] PawnTemplate { get; }

        int[][] CellTemplate { get; }

        Dictionary<GameColor, GameDirection> PawnDirections { get; }

        IGamePlayer[] Players { get; }
    }
}
