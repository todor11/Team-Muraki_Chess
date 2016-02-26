namespace Chess.Contracts
{
    using Chess.Enums;
    using Chess.Models;

    public interface IPawnManufacturer
    {
        IPawn ManufacturePawn(GameColor pawnColor);
    }
}
