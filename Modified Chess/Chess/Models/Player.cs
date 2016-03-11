namespace Chess.Models
{
    using System.Collections.Generic;

    using Contracts;
    using Enums;

    public class Player : IGamePlayer
    {
        public Player(GameColor pawnColor)
        {
            this.PawnColor = pawnColor;
            this.Pawns = new List<IPawn>();
        }

        public string Name { get; set; }

        public GameColor PawnColor { get; set; }

        public IList<IPawn> Pawns { get; }

        public virtual void MakeNextMove()
        {
        }
    }
}
