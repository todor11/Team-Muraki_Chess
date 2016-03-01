namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IGamePlayer
    {
        string Name { get; }

        GameColor PawnColor { get; }

        IList<IPawn> Pawns { get; }

        void MakeNextMove();
    }
}
