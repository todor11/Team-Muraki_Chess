namespace Chess.UI
{
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

        private readonly List<PictureBox> pawnsPictureBoxs = new List<PictureBox>();

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
                        newPawn.Name = pawnColor.ToString() + i + j;
                        newPawn.Size = new System.Drawing.Size(this.pawnPositionStepX, this.pawnPositionStepY);
                        newPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        newPawn.TabIndex = 1;
                        newPawn.TabStop = false;

                        this.pawnsPictureBoxs.Add(newPawn);
                        this.boardImage.Controls.Add(newPawn);
                    }
                }
            }
            
            for (int i = 0; i < this.pawnsPictureBoxs.Count; i++)
            {
                this.pawnsPictureBoxs[i].MouseDown += (ss, ee) =>
                    {
                        if (ee.Button == MouseButtons.Left)
                        {
                            this.firstPoint = MousePosition;
                            PictureBox currentPictureBox = ss as PictureBox;
                            this.boardImage.Controls.Clear();
                            this.boardImage.Controls.Add(currentPictureBox);
                            int currentPawnIndex = this.pawnsPictureBoxs.IndexOf(currentPictureBox);
                            for (int j = 0; j < this.pawnsPictureBoxs.Count; j++)
                            {
                                if (j != currentPawnIndex)
                                {
                                    this.boardImage.Controls.Add(this.pawnsPictureBoxs[j]);
                                }
                            }
                        }
                    };

                this.pawnsPictureBoxs[i].MouseMove += (ss, ee) =>
                    {
                        if (ee.Button == MouseButtons.Left)
                        {
                            this.temp = MousePosition;
                            this.distanceBetweenPreviousAndTemporary = new Point(this.firstPoint.X - this.temp.X, this.firstPoint.Y - this.temp.Y);
                            PictureBox currentPictureBox = ss as PictureBox;
                            currentPictureBox.Location = new Point(
                                currentPictureBox.Location.X - this.distanceBetweenPreviousAndTemporary.X, 
                                currentPictureBox.Location.Y - this.distanceBetweenPreviousAndTemporary.Y);

                            this.firstPoint = this.temp;
                        }
                    };
                
                this.pawnsPictureBoxs[i].MouseUp += (ss, ee) =>
                {
                    if (ee.Button == MouseButtons.Left)
                    {
                        this.temp = MousePosition;
                        this.distanceBetweenPreviousAndTemporary = new Point(this.firstPoint.X - this.temp.X, this.firstPoint.Y - this.temp.Y);
                        PictureBox currentPictureBox = ss as PictureBox;
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
                    }
                };
            }
        }
    }
}