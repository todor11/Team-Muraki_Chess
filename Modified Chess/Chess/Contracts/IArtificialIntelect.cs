namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IArtificialIntelect
    {
        IGameBoard GameBoard { get; }

        IEnumerable<ICell> GetMoveFromTo();
    }
}
