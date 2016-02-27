namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class GameFigurePositionsTemplate : IGameFigurePositionsTemplate
    {
        private readonly int[][] pawnColorTemplate;

        private readonly int[][] cellColorTemplate;

        public GameFigurePositionsTemplate()
        {
            this.pawnColorTemplate = new[] {
                                                            new int[] { 0, 2, 0, 2, 0, 2, 0, 2 },
                                                            new int[] { 2, 0, 2, 0, 2, 0, 2, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 1, 0, 1, 0, 1, 0, 1, 0 },
                                                            new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }
                                                            };

            this.cellColorTemplate = new[] {
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

        public int[][] PawnColorTemplate
        {
            get
            {
                return this.pawnColorTemplate;
            }
        }

        public int[][] CellColorTemplate
        {
            get
            {
                return this.cellColorTemplate;
            }
        }
    }
}
