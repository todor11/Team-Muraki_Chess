namespace Chess.Contracts
{
    using Utilities;

    public delegate void CompsMoveEventHandler(IArtificialIntelect sender, CompsMoveEventArgs args);

    public interface IArtificialIntelect : IGamePlayer
    {
        event CompsMoveEventHandler ComputersMove;

        IEngine Engine { get; set; }

        void GetMoveFromTo();
    }
}
