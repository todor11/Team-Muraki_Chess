namespace Chess.Models
{
    using System.Collections.Generic;

    using Contracts;
    using Enums;

    public class UserTemplateCreator : IGameTemplateCreator
    {
        public IGameTemplate CreateTemplate(
            int sizeOfBoard,
            int numberOfPawns,
            IGamePlayer[] playersTypes,
            GameDirection[] playersDirections)
        {
            var template = new UserGameTemplate();
            int[][] pawnTemplate = this.PawnTemplate(sizeOfBoard, numberOfPawns, playersTypes, playersDirections);
            template.PawnTemplate = pawnTemplate;
            template.PawnDirections = this.CreatePawnDirection(playersTypes, playersDirections);
            template.Players = playersTypes;
            template.CellTemplate = this.CreateCellTemplate(numberOfPawns);

            return template;
        }

        private int[][] CreateCellTemplate(int numberOfPawns)
        {
            var cellTemplate = new[] 
                                    {
                                    new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                    new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                    new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                    new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                    new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                    new int[] { 2, 1, 2, 1, 2, 1, 2, 1 },
                                    new int[] { 1, 2, 1, 2, 1, 2, 1, 2 },
                                    new int[] { 2, 1, 2, 1, 2, 1, 2, 1 }
                                    };

            return cellTemplate;
        }

        private Dictionary<GameColor, GameDirection> CreatePawnDirection(IGamePlayer[] players, GameDirection[] playersDirections)
        {
            var pawnDirections = new Dictionary<GameColor, GameDirection>();
            for (int i = 0; i < players.Length; i++)
            {
                pawnDirections[players[i].PawnColor] = playersDirections[i];
            }

            return pawnDirections;
        }

        private int[][] PawnTemplate(int sizeOfBoard, int numberOfPawns, IGamePlayer[] playersTypes, GameDirection[] playersDirections)
        {
            int[][] pawnTemplate = new int[sizeOfBoard][];
            for (int i = 0; i < sizeOfBoard; i++)
            {
                pawnTemplate[i] = new int[sizeOfBoard];
            }

            this.FillPlayerOnePawns(pawnTemplate, playersTypes[0]);
            this.FillPlayerTwoPawns(pawnTemplate, playersTypes[1]);
            if (playersTypes.Length > 2)
            {
                this.FillPlayerTreePawns(pawnTemplate, playersTypes[2]);
            }

            if (playersTypes.Length > 3)
            {
                this.FillPlayerFourPawns(pawnTemplate, playersTypes[3]);
            }

            return pawnTemplate;
        }

        private void FillPlayerOnePawns(int[][] pawnTemplate, IGamePlayer player)
        {
            pawnTemplate[0][1] = (int)player.PawnColor;
            pawnTemplate[0][3] = (int)player.PawnColor;
            pawnTemplate[0][5] = (int)player.PawnColor;
            pawnTemplate[0][7] = (int)player.PawnColor;
            pawnTemplate[1][2] = (int)player.PawnColor;
            pawnTemplate[1][4] = (int)player.PawnColor;
            pawnTemplate[1][6] = (int)player.PawnColor;
            pawnTemplate[1][0] = (int)player.PawnColor;
        }

        private void FillPlayerTwoPawns(int[][] pawnTemplate, IGamePlayer player)
        {
            pawnTemplate[6][0] = (int)player.PawnColor;
            pawnTemplate[6][2] = (int)player.PawnColor;
            pawnTemplate[6][4] = (int)player.PawnColor;
            pawnTemplate[6][6] = (int)player.PawnColor;
            pawnTemplate[7][1] = (int)player.PawnColor;
            pawnTemplate[7][3] = (int)player.PawnColor;
            pawnTemplate[7][5] = (int)player.PawnColor;
            pawnTemplate[7][7] = (int)player.PawnColor;
        }

        private void FillPlayerTreePawns(int[][] pawnTemplate, IGamePlayer player)
        {
            pawnTemplate[0][0] = (int)player.PawnColor;
            pawnTemplate[2][0] = (int)player.PawnColor;
            pawnTemplate[4][0] = (int)player.PawnColor;
            pawnTemplate[7][0] = (int)player.PawnColor;
            pawnTemplate[1][1] = (int)player.PawnColor;
            pawnTemplate[3][1] = (int)player.PawnColor;
            pawnTemplate[5][1] = (int)player.PawnColor;
            pawnTemplate[6][1] = (int)player.PawnColor;
        }

        private void FillPlayerFourPawns(int[][] pawnTemplate, IGamePlayer player)
        {
            pawnTemplate[0][6] = (int)player.PawnColor;
            pawnTemplate[2][6] = (int)player.PawnColor;
            pawnTemplate[4][6] = (int)player.PawnColor;
            pawnTemplate[7][6] = (int)player.PawnColor;
            pawnTemplate[1][7] = (int)player.PawnColor;
            pawnTemplate[3][7] = (int)player.PawnColor;
            pawnTemplate[5][7] = (int)player.PawnColor;
            pawnTemplate[6][7] = (int)player.PawnColor;
        }
    }
}
