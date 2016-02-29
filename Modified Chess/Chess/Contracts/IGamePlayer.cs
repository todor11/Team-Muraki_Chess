namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IGamePlayer
    {
        string Name { get; }

        IEnumerable<IPawn> Pawns { get; }

        void MakeNextMove();
    }
}
