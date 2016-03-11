namespace Chess.Models
{
    using System.Collections.Generic;

    using Contracts;
    using Enums;

    public class UserGameTemplate : IGameTemplate
    {
        public int[][] PawnTemplate { get; set; }

        public int[][] CellTemplate { get; set; }

        public Dictionary<GameColor, GameDirection> PawnDirections { get; set; }

        public IGamePlayer[] Players { get; set; }
    }
}
