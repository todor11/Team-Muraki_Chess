namespace Chess.Models
{
    using Chess.Contracts;
    using Chess.Enums;
    using Chess.Utilities;

    public class GameBoard : IGameBoard
    {
        private readonly IPawnsPositionsTemplate pawnsPositionsTemplate;
        
        public GameBoard(IPawnsPositionsTemplate pawnsPositionsTemplate, ICellManufacturer cellManufacturer)
        {
            this.pawnsPositionsTemplate = pawnsPositionsTemplate;
            this.Cells = new ICell[this.pawnsPositionsTemplate.Template.Length][];
            this.CellFactory = cellManufacturer;
            this.Init();
        }

        public ICell[][] Cells { get; private set; }

        public ICellManufacturer CellFactory { get; private set; }

        public void Init()//TODO - to depend only on PawnsPositionsTemplate and new gameBardColors
        {
            bool isCurrentColorWhite = false;
            for (int i = 0; i < this.pawnsPositionsTemplate.Template.Length; i++)
            {
                if (isCurrentColorWhite)
                {
                    isCurrentColorWhite = false;
                }
                else
                {
                    isCurrentColorWhite = true;
                }

                this.Cells[i] = new ICell[this.pawnsPositionsTemplate.Template[i].Length];

                for (int j = 0; j < this.pawnsPositionsTemplate.Template[i].Length; j++)
                {
                    if (isCurrentColorWhite)
                    {
                        if (this.pawnsPositionsTemplate.Template[i][j] == 1)
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.White, GameColor.White);
                            isCurrentColorWhite = false;
                        }
                        else if (this.pawnsPositionsTemplate.Template[i][j] == 2)
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.White, GameColor.Black);
                            isCurrentColorWhite = false;
                        }
                        else
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.White);
                            isCurrentColorWhite = false;
                        }
                    }
                    else
                    {
                        if (this.pawnsPositionsTemplate.Template[i][j] == 1)
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.Black, GameColor.White);
                            isCurrentColorWhite = true;
                        }
                        else if (this.pawnsPositionsTemplate.Template[i][j] == 2)
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.Black, GameColor.Black);
                            isCurrentColorWhite = true;
                        }
                        else
                        {
                            this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, GameColor.Black);
                            isCurrentColorWhite = true;
                        }
                    }
                }
            }
        }
    }
}