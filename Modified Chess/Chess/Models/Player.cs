﻿namespace Chess.Models
{
    using System.Collections.Generic;

    using Chess.Contracts;

    public class Player : IGamePlayer
    {
        //TODO
        public string Name { get; }

        public IEnumerable<IPawn> Pawns { get; }

        public virtual void MakeNextMove()
        {
        }
    }
}
