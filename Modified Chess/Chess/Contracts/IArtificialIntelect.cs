namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IArtificialIntelect
    {
        IEngine GameEngine { get; }

        IEnumerable<ICell> GetMoveFromTo();
    }
}
