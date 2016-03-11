namespace Chess.Models
{
    using System.Linq;

    using Contracts;
    using Enums;

    public class GameBoard : IGameBoard
    {
        private readonly IGameTemplate gameTemplate;
        
        public GameBoard(IGameTemplate gameTemplate, ICellManufacturer cellManufacturer)
        {
            this.gameTemplate = gameTemplate;
            this.Cells = new ICell[this.gameTemplate.PawnTemplate.Length][];
            this.CellFactory = cellManufacturer;
            this.Pawns = new IPawn[this.gameTemplate.PawnTemplate.Select(n => n.Where(el => el != 0).Count()).Sum()];
            this.Init();
        }

        public ICell[][] Cells { get; private set; }

        public IPawn[] Pawns { get; }

        public ICellManufacturer CellFactory { get; private set; }

        public IGameTemplate GameTemplate
        {
            get
            {
                return this.gameTemplate;
            }
        }

        public void Init()
        {
            int currentPawrIndex = 0;
            for (int i = 0; i < this.gameTemplate.CellTemplate.Length; i++)
            {
                this.Cells[i] = new ICell[this.gameTemplate.CellTemplate[i].Length];
                for (int j = 0; j < this.gameTemplate.CellTemplate[i].Length; j++)
                {
                    GameColor currentCellColor = (GameColor)this.gameTemplate.CellTemplate[i][j];
                    GameColor currentPawnColor = (GameColor)this.gameTemplate.PawnTemplate[i][j];
                    if (currentPawnColor == 0)
                    {
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor);
                    }
                    else
                    {
                        GameDirection currentPawnDirection =
                            this.gameTemplate.PawnDirections[currentPawnColor];
                        this.Cells[i][j] = this.CellFactory.ManufactureCell(i, j, currentCellColor, currentPawnColor, currentPawnDirection);
                        this.Pawns[currentPawrIndex] = this.Cells[i][j].Pawn;
                        
                        for (int k = 0; k < this.gameTemplate.Players.Length; k++)
                        {
                            if (this.gameTemplate.Players[k].PawnColor == currentPawnColor)
                            {
                                this.gameTemplate.Players[k].Pawns.Add(this.Cells[i][j].Pawn);
                                break;
                            }
                        }

                        currentPawrIndex++;
                    }
                }
            }
        }

        public void NotifyPawnsForChanges()
        {
            foreach (var pawn in this.Pawns)
            {
                pawn.UpdatePosibleMoves(this.Cells);
            }
        }
    }
}