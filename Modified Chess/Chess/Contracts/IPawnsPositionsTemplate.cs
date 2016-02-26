namespace Chess.Contracts
{
    using System.Collections.Generic;

    using Chess.Enums;

    public interface IPawnsPositionsTemplate
    {
        int[][] Template { get; }

        HashSet<GameColor> ActiveGameColors { get; }
    }
}
