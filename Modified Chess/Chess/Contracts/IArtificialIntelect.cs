namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IArtificialIntelect: IGamePlayer
    {
        IEngine Engine { get; set; }

        void GetMoveFromTo();
    }
}
