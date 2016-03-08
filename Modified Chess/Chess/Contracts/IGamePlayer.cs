namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IGamePlayer
    {
        string Name { get; set; }

        GameColor PawnColor { get; set; }

        IList<IPawn> Pawns { get; }

        void MakeNextMove();
    }
}
