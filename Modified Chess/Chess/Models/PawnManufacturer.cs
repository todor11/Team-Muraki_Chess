namespace Chess.Models
{
    using Contracts;
    using Enums;

    public class PawnManufacturer : IPawnManufacturer
    {
        public IPawn ManufacturePawn(GameColor pawnColor, GameDirection pawnDirection)
        {
            return new Pawn(pawnColor, pawnDirection);
        }
    }
}
