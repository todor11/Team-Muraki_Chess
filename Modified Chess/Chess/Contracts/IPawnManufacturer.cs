namespace Chess.Contracts
{
    using Enums;

    public interface IPawnManufacturer
    {
        IPawn ManufacturePawn(GameColor pawnColor, GameDirection pawnDirection);
    }
}
