namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class PawnsPositionsTemplate : IPawnsPositionsTemplate
    {
        private readonly int[][] template;

        private readonly HashSet<GameColor> activeGameColors;

        public PawnsPositionsTemplate()
        {
            this.template = new[] {
                                                            new int[] { 0, 2, 0, 2, 0, 2, 0, 2 },
                                                            new int[] { 2, 0, 2, 0, 2, 0, 2, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                            new int[] { 1, 0, 1, 0, 1, 0, 1, 0 },
                                                            new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }
                                                            };

            this.activeGameColors = new HashSet<GameColor>() { GameColor.White, GameColor.Black };
        }

        public int[][] Template
        {
            get
            {
                return this.template;
            }
        }

        public HashSet<GameColor> ActiveGameColors
        {
            get
            {
                return this.activeGameColors;
            }
        }
    }
}
