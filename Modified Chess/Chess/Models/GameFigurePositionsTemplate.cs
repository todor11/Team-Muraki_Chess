namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class GameFigurePositionsTemplate : IGameFigurePositionsTemplate
    {
        private readonly int[][] pawnTemplate;

        private readonly int[][] cellTemplate;

        private readonly Dictionary<GameColor, GameDirection> pawnDirections;

        public GameFigurePositionsTemplate()
        {
            this.pawnTemplate = new[] {
                                                            new int[] { 0, 3, 0, 3, 0, 3, 0, 3 },
                                                            new int[] { 3, 0, 3, 0, 3, 0, 3, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 1, 0, 1, 0, 1, 0, 1, 0 },
                                                            new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }
                                                            };

            this.cellTemplate = new[] {
                                                            new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                                            new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                                            new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                                            new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                                            new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                                            new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                                            new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                                            new int[] { 2, 1, 2, 1, 2, 1, 2, 1 }
                                                            };

            this.pawnDirections = new Dictionary<GameColor, GameDirection>();
            this.pawnDirections.Add(GameColor.White, GameDirection.Up);
            this.pawnDirections.Add(GameColor.Red, GameDirection.Down);
            this.Players = new IGamePlayer[]
                               {
                                   new Player(GameColor.White), 
                                   new AI(GameColor.Red)
                               };
        }

        public int[][] PawnTemplate
        {
            get
            {
                return this.pawnTemplate;
            }
        }

        public int[][] CellTemplate
        {
            get
            {
                return this.cellTemplate;
            }
        }

        public Dictionary<GameColor, GameDirection> PawnDirections
        {
            get
            {
                return this.pawnDirections;
            }
        }

        public IGamePlayer[] Players { get; }
    }
}
