namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IStatistic
    {
        IEnumerable<IGameResult> TopResults { get; }
    }
}