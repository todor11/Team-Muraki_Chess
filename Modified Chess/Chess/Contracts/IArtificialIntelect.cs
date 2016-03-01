namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IArtificialIntelect
    {
        IEngine Engine { get; }

        void GetMoveFromTo();
    }
}
