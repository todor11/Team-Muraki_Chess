namespace Chess.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMovesCounter
    {
        int Counter { get; }

        void UpdateCounter();
    }
}
