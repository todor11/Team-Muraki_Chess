namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IGameCreator
    {
        int NumberOfPlayers { get; }

        int NumberOfPawns { get; }

        IGamePlayer[] Players { get; }

        GameDirection[] PlayersDirections { get; }

        string[] PlayersNames { get; }

        IGameTemplateCreator TemplateCreator { get; }

        void StartGame();

        void EndGame();
    }
}
