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

        private const int FirstPawnStartPointY = 2;

        private readonly int pawnPositionStepX;

        private readonly int pawnPositionStepY;

        private readonly Dictionary<GameColor, List<PictureBox>> pawnsPictureBoxsDictionary = new Dictionary<GameColor, List<PictureBox>>();

        private Point firstPoint;

        private Point distanceBetweenPreviousAndTemporary;

        private Point temp;

        public UserDesk(IEngine engine)
        {
            this.Engine = engine;
            this.Engine.UserForm = this;
            this.pawnPositionStepX = BoardSizeX / this.Engine.GameBoard.Cells.Length;
            this.pawnPositionStepY = BoardSizeY / this.Engine.GameBoard.Cells[0].Length;
            
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
                        newPawn.Name = pawnColor.ToString() + i + j;//TODO
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

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];
            if (e.Button == MouseButtons.Left)
            {
                this.temp = MousePosition;
                this.distanceBetweenPreviousAndTemporary = new Point(this.firstPoint.X - this.temp.X, this.firstPoint.Y - this.temp.Y);
                PictureBox currentPictureBox = sender as PictureBox;
                int newCurrentPictureBoxLocationX = ((currentPictureBox.Location.X - this.distanceBetweenPreviousAndTemporary.X +
                    (pawnPositionStepX / 2)) - FirstPawnStartPointX) / pawnPositionStepX;
                newCurrentPictureBoxLocationX = (newCurrentPictureBoxLocationX * pawnPositionStepX) + FirstPawnStartPointX;
                int newCurrentPictureBoxLocationY = ((currentPictureBox.Location.Y - this.distanceBetweenPreviousAndTemporary.Y +
                    (pawnPositionStepY / 2)) - FirstPawnStartPointY) / pawnPositionStepY;
                newCurrentPictureBoxLocationY = (newCurrentPictureBoxLocationY * pawnPositionStepY) + FirstPawnStartPointY;

                currentPictureBox.Location = new Point(
                    newCurrentPictureBoxLocationX,
                    newCurrentPictureBoxLocationY);

                this.firstPoint = this.temp;

                this.RemoveEventHolders();
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];
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

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            var currPlayerPictureBoxes = this.pawnsPictureBoxsDictionary[this.Engine.ActivePlayer.PawnColor];

            if (e.Button == MouseButtons.Left)
            {
                this.firstPoint = MousePosition;
                PictureBox currentPictureBox = sender as PictureBox;
                this.boardImage.Controls.Clear();
                this.boardImage.Controls.Add(currentPictureBox);

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
    }
}