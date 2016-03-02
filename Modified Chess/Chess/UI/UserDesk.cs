namespace Chess.UI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    using Chess.Contracts;
    using Chess.Utilities;

    using Chess.Enums;

    public partial class UserDesk : Form, IFormDesk
    {
        private const int BoardStartPointX = 50;

        private const int BoardStartPointY = 50;

        private const int BoardSizeX = 600;

        private const int BoardSizeY = 570;

        private const int FirstPawnStartPointX = 0;

        private const int FirstPawnStartPointY = 0;

        private readonly int pawnPositionStepX;

        private readonly int pawnPositionStepY;

        private readonly Dictionary<GameColor, List<PictureBox>> pawnsPictureBoxsDictionary = new Dictionary<GameColor, List<PictureBox>>();

        private readonly HashSet<string> activePawnPosibleCells;

        private Point firstPoint;

        private Point distanceBetweenPreviousAndTemporary;

        private Point temp;

        private Point pawnStartPoint;

        public UserDesk(IEngine engine)
        {
            this.Engine = engine;
            this.Engine.UserForm = this;
            this.pawnPositionStepX = BoardSizeX / this.Engine.GameBoard.Cells.Length;
            this.pawnPositionStepY = BoardSizeY / this.Engine.GameBoard.Cells[0].Length;
            this.activePawnPosibleCells = new HashSet<string>();

            this.InitializeComponent();
            
            this.Init();
        }

        public IEngine Engine { get; private set; }

        private void Init()
        {
            this.boardImage.Location = new Point(BoardStartPointX, BoardStartPointY);
            this.boardImage.Size = new Size(BoardSizeX, BoardSizeY);
            
            int maxI = this.Engine.GameBoard.Cells.Length;
            for (int i = 0; i < maxI; i++)
            {
                int maxJ = this.Engine.GameBoard.Cells[i].Length;
                for (int j = 0; j < maxJ; j++)
                {
                    if (!this.Engine.GameBoard.Cells[i][j].IsFree)
                    {
                        PictureBox newPawn = new PictureBox();
                        newPawn.BackColor = System.Drawing.Color.Transparent;
                        GameColor pawnColor = this.Engine.GameBoard.Cells[i][j].Pawn.Color;
                        if (pawnColor == GameColor.Black)
                        {
                            newPawn.Image = global::Chess.Properties.Resources.black_pawn;
                        }
                        else
                        {
                            newPawn.Image = global::Chess.Properties.Resources.white_pawn;
                        }
                        
                        newPawn.Location = new System.Drawing.Point(
                            FirstPawnStartPointX + (j * this.pawnPositionStepX), FirstPawnStartPointY + (i * this.pawnPositionStepY));
                        newPawn.Name = i + "," + j;
                        newPawn.Size = new System.Drawing.Size(this.pawnPositionStepX, this.pawnPositionStepY);
                        newPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        newPawn.TabIndex = 1;
                        newPawn.TabStop = false;
                        if (!this.pawnsPictureBoxsDictionary.ContainsKey(pawnColor))
                        {
                            this.pawnsPictureBoxsDictionary[pawnColor] = new List<PictureBox>();
                        }

                        this.pawnsPictureBoxsDictionary[pawnColor].Add(newPawn);
                        this.boardImage.Controls.Add(newPawn);
                    }
                }
            }
            
            this.SetEventHolders();
        }

        private void SetEventHolders()
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];

            for (int i = 0; i < currPlayerPictureBoxes.Count; i++)
            {
                currPlayerPictureBoxes[i].MouseDown += this.PictureBoxMouseDown;

                currPlayerPictureBoxes[i].MouseMove += this.PictureBoxMouseMove;

                currPlayerPictureBoxes[i].MouseUp += this.PictureBoxMouseUp;
            }
        }

        private void RemoveEventHolders()
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];

            foreach (var pictureBox in currPlayerPictureBoxes)
            {
                pictureBox.MouseDown -= this.PictureBoxMouseDown;
                pictureBox.MouseMove -= this.PictureBoxMouseMove;
                pictureBox.MouseUp -= this.PictureBoxMouseUp;
            }
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];

            if (e.Button == MouseButtons.Left)
            {
                this.firstPoint = MousePosition;
                PictureBox currentPictureBox = sender as PictureBox;
                this.boardImage.Controls.Clear();
                this.boardImage.Controls.Add(currentPictureBox);
                
                this.pawnStartPoint = currentPictureBox.Location;
                this.activePawnPosibleCells.Clear();
                string[] cellCoordinates = currentPictureBox.Name.Split(',');
                var currantPawn =
                    this.Engine.GameBoard.Cells[int.Parse(cellCoordinates[0])][int.Parse(cellCoordinates[1])].Pawn;
                foreach (var cell in currantPawn.PosibleMoves)
                {
                    this.activePawnPosibleCells.Add(cell.Row + "," + cell.Col);
                }
                
                foreach (List<PictureBox> setOfEachPlayerPictureBoxes in this.pawnsPictureBoxsDictionary.Values)
                {
                    if (setOfEachPlayerPictureBoxes != currPlayerPictureBoxes)
                    {
                        for (int j = 0; j < setOfEachPlayerPictureBoxes.Count; j++)
                        {
                            this.boardImage.Controls.Add(setOfEachPlayerPictureBoxes[j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < setOfEachPlayerPictureBoxes.Count; j++)
                        {
                            if (setOfEachPlayerPictureBoxes[j] != currentPictureBox)
                            {
                                this.boardImage.Controls.Add(setOfEachPlayerPictureBoxes[j]);
                            }
                        }
                    }
                }
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.temp = MousePosition;
                this.distanceBetweenPreviousAndTemporary = new Point(this.firstPoint.X - this.temp.X, this.firstPoint.Y - this.temp.Y);
                PictureBox currentPictureBox = sender as PictureBox;
                int newCol = ((currentPictureBox.Location.X - this.distanceBetweenPreviousAndTemporary.X +
                    (this.pawnPositionStepX / 2)) - FirstPawnStartPointX) / this.pawnPositionStepX;
                int newCurrentPictureBoxLocationX = (newCol * this.pawnPositionStepX) + FirstPawnStartPointX;
                int newRow = ((currentPictureBox.Location.Y - this.distanceBetweenPreviousAndTemporary.Y +
                    (this.pawnPositionStepY / 2)) - FirstPawnStartPointY) / this.pawnPositionStepY;
                int newCurrentPictureBoxLocationY = (newRow * this.pawnPositionStepY) + FirstPawnStartPointY;

                //
                string newStringPosition = newRow + "," + newCol;
                if (this.activePawnPosibleCells.Contains(newStringPosition))
                {
                    currentPictureBox.Location = new Point(
                    newCurrentPictureBoxLocationX,
                    newCurrentPictureBoxLocationY);

                    string[] splitedStringPictureBoxName = currentPictureBox.Name.Split(',');
                    int oldRow = int.Parse(splitedStringPictureBoxName[0]);
                    int oldCol = int.Parse(splitedStringPictureBoxName[1]);
                    currentPictureBox.Name = newRow + "," + newCol;
                    this.firstPoint = this.temp;
                    this.RemoveEventHolders();
                    this.Engine.MovePawnFromTo(this.Engine.GameBoard.Cells[oldRow][oldCol], this.Engine.GameBoard.Cells[newRow][newCol]);

                    this.SetEventHolders();
                }
                else
                {
                    currentPictureBox.Location = this.pawnStartPoint;
                }
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.temp = MousePosition;
                this.distanceBetweenPreviousAndTemporary = new Point(this.firstPoint.X - this.temp.X, this.firstPoint.Y - this.temp.Y);
                PictureBox currentPictureBox = sender as PictureBox;
                currentPictureBox.Location = new Point(
                    currentPictureBox.Location.X - this.distanceBetweenPreviousAndTemporary.X,
                    currentPictureBox.Location.Y - this.distanceBetweenPreviousAndTemporary.Y);

                this.firstPoint = this.temp;
            }
        }
    }
}