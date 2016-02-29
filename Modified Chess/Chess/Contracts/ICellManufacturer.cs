﻿namespace Chess.Contracts
{
    using Chess.Enums;
    using Chess.Models;

    public interface ICellManufacturer
    {
        IPawnManufacturer PawnManufacturer { get; }

        ICell ManufactureCell(int row, int col, GameColor cellColor, GameColor pawnColor, GameDirection direction);

        ICell ManufactureCell(int row, int col, GameColor cellColor);
    }
}
