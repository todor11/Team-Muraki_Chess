namespace Chess.Contracts
{
    using Enums;

    public interface IGameManager
    {
        int NumberOfPlayers { get; }

        int NumberOfPawns { get; }

        IStatistic Statistic { get; }

        IGamePlayer[] Players { get; }

        GameDirection[] PlayersDirections { get; }

        string[] PlayersNames { get; }

        IGameTemplateCreator TemplateCreator { get; }

        void StartGame();

        void EndGame();
    }
}
