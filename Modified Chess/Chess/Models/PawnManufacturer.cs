namespace Chess.Models
{
    using Chess.Contracts;
    using Chess.Enums;

    public class PawnManufacturer : IPawnManufacturer
    {
        public IPawn ManufacturePawn(GameColor pawnColor, GameDirection pawnDirection)
        {
            return new Pawn(pawnColor, pawnDirection);
        }
    }
}
