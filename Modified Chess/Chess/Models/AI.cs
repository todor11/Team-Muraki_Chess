namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    public class AI : Player, IArtificialIntelect
    {
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
