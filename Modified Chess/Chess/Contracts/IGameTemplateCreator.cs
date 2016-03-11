namespace Chess.Contracts
{
    using Enums;

    public interface IGameTemplateCreator
    {
        IGameTemplate CreateTemplate(int sizeOfBoard, int numberOfPawns, IGamePlayer[] playersTypes, GameDirection[] playersDirections);
    }
}
