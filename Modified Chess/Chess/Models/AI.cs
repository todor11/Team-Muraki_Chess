namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;
    public class AI : Player, IArtificialIntelect
    {
        //TODO
        public IEngine GameEngine { get; }

        public IEnumerable<ICell> GetMoveFromTo()
        {
            throw new System.NotImplementedException();
        }
    }
}
