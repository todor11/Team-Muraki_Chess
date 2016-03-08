namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class UserGameTemplate : IGameTemplate
    {
        public int[][] PawnTemplate { get; set; }

        public int[][] CellTemplate { get; set; }

        public Dictionary<GameColor, GameDirection> PawnDirections { get; set; }

        public IGamePlayer[] Players { get; set; }
    }
}
