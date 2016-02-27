namespace Chess.Models
{
    using Chess.Contracts;
    using Chess.Enums;

    public class GameBoard : IGameBoard
    {
        private readonly IGameFigurePositionsTemplate gameFigurePositionsTemplate;
        
        public GameBoard(IGameFigurePositionsTemplate gameFigurePositionsTemplate, ICellManufacturer cellManufacturer)
        {
            this.gameFigurePositionsTemplate = gameFigurePositionsTemplate;
            this.Cells = new ICell[this.gameFigurePositionsTemplate.PawnColorTemplate.Length][];
            this.CellFactory = cellManufacturer;
            this.Init();
        }

        public ICell[][] Cells { get; private set; }

        public ICellManufacturer CellFactory { get; private set; }

        public void Init()
        {
            for (int i = 0; i < this.gameFigurePositionsTemplate.CellColorTemplate.Length; i++)
            {
                this.Cells[i] = new ICell[this.gameFigurePositionsTemplate.CellColorTemplate[i].Length];
                for (int j = 0; j < this.gameFigurePositionsTemplate.CellColorTemplate[i].Length; j++)
                {
                    GameColor currentCellColor = (GameColor)this.gameFigurePositionsTemplate.CellColorTemplate[i][j];
                    GameColor currentPawnColor = (GameColor)this.gameFigurePositionsTemplate.PawnColorTemplate[i][j];
                    if (currentPawnColor == 0)
                    {
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor);
                    }
                    else
                    {
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor, currentPawnColor);
                    }
                }
            }
        }
    }
}