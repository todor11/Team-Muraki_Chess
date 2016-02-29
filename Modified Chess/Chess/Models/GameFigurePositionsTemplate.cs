namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class GameFigurePositionsTemplate : IGameFigurePositionsTemplate
    {
        private readonly int[][] pawnTemplate;

        private readonly int[][] cellTemplate;

        public GameFigurePositionsTemplate()
        {
            this.pawnTemplate = new[] {
                                                            new int[] { 0, 2, 0, 2, 0, 2, 0, 2 },
                                                            new int[] { 2, 0, 2, 0, 2, 0, 2, 0 },
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
    }
}
