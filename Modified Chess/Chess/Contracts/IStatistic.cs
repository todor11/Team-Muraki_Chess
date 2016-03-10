namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IStatistic
    {
        IEnumerable<IGameResult> TopResults { get; }

        string GetStatistic();

        void SaveResult(string name, int result);

        void SaveStatistic();
    }
}