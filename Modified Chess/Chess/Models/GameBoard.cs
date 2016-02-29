namespace Chess.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Chess.Contracts;
    using Chess.Enums;

    public class GameBoard : IGameBoard
    {
        private readonly IGameFigurePositionsTemplate gameFigurePositionsTemplate;
        
        public GameBoard(IGameFigurePositionsTemplate gameFigurePositionsTemplate, ICellManufacturer cellManufacturer)
        {
            this.gameFigurePositionsTemplate = gameFigurePositionsTemplate;
            this.Cells = new ICell[this.gameFigurePositionsTemplate.PawnTemplate.Length][];
            this.CellFactory = cellManufacturer;
            this.Pawns = new IPawn[this.gameFigurePositionsTemplate.PawnTemplate.Select(n => n.Where(el => el != 0).Count()).Sum()];
            this.Init();
        }

        public ICell[][] Cells { get; private set; }

        public IEnumerable<IPawn> Pawns { get; }

        public ICellManufacturer CellFactory { get; private set; }

        public IGameFigurePositionsTemplate GameTemplate
        {
            get
            {
                return this.gameFigurePositionsTemplate;
            }
        }

        public void Init()
        {
            for (int i = 0; i < this.gameFigurePositionsTemplate.CellTemplate.Length; i++)
            {
                this.Cells[i] = new ICell[this.gameFigurePositionsTemplate.CellTemplate[i].Length];
                for (int j = 0; j < this.gameFigurePositionsTemplate.CellTemplate[i].Length; j++)
                {
                    GameColor currentCellColor = (GameColor)this.gameFigurePositionsTemplate.CellTemplate[i][j];
                    GameColor currentPawnColor = (GameColor)this.gameFigurePositionsTemplate.PawnTemplate[i][j];
                    if (currentPawnColor == 0)
                    {
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor);
                    }
                    else
                    {
                        GameDirection currentPawnDirection =
                            this.gameFigurePositionsTemplate.PawnDirections[currentPawnColor];
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor, currentPawnColor, currentPawnDirection);
                    }
                }
            }
        }
    }
}