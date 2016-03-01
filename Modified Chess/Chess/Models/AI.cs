namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    using Chess.Enums;

    public class AI : Player, IArtificialIntelect
    {
        public AI(GameColor pawnColor)
           : base(pawnColor)
        {
        }

        public IEngine Engine { get; }

        public void GetMoveFromTo()
        {
            //TODO
        }

        public override void MakeNextMove()
        {
            this.GetMoveFromTo();
            this.GetMoveFromTo();
        }
    }
}
