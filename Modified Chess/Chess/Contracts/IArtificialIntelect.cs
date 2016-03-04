namespace Chess.Contracts
{
    using Chess.Models;

    public interface IArtificialIntelect : IGamePlayer
    {
        event CompsMoveEventHandler ComputersMove;

        IEngine Engine { get; set; }

        void GetMoveFromTo();
    }
}
