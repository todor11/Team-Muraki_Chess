namespace Chess.Contracts
{
    using System;

    using Chess.Enums;

    public interface IGameTemplateCreator
    {
        IGameTemplate CreateTemplate(int sizeOfBoard, int numberOfPawns, IGamePlayer[] playersTypes, GameDirection[] playersDirections);
    }
}
