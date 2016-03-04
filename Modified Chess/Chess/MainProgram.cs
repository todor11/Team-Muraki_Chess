﻿namespace Chess
{
    using System;
    using System.Windows.Forms;

    using Chess.Core;
    using Chess.Models;
    using Chess.UI;

    public static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var gameTemplate = new GameTemplate();
            var pawnManufacturer = new PawnManufacturer();
            var cellManufacturer = new CellManufacturer(pawnManufacturer);
            var gameBoard = new GameBoard(gameTemplate, cellManufacturer);
            var engine = new Engine(gameBoard);
            engine.Run();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserDesk(engine));
            
        }
    }
}