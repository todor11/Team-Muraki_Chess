namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class Player : IGamePlayer
    {
        public Player(GameColor pawnColor)
        {
            this.PawnColor = pawnColor;
            this.Pawns = new List<IPawn>();
        }

        public string Name { get; }

        public GameColor PawnColor { get; }

        public IList<IPawn> Pawns { get; }

        public virtual void MakeNextMove()
        {
        }
    }
}
