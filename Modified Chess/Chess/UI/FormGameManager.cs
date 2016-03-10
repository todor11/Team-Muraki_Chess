namespace Chess.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using Chess.Contracts;
    using Chess.Core;
    using Chess.Enums;
    using Chess.Models;
    using Chess.Utilities;

    public partial class FormGameManager : Form, IGameManager
    {
        private const int NumberOfGameColors = 4;

        private readonly Dictionary<string, Type> RaceTypeDictionary;

        private IEngine engine;

        private string rules;

        private List<GameColor> freeColors;

        private List<string> freeColorsAsString;

        private Form userForm;

        public FormGameManager(IGameTemplateCreator templateCreator, IStatistic statistic)
        {
            this.Statistic = statistic;
            this.TemplateCreator = templateCreator;
            this.RaceTypeDictionary = new Dictionary<string, Type>();
            this.GetPlayerTypes();
            this.InitializeComponent();
            this.HideElementsWhenStart();
            this.SetStartGameColors();
            this.GetRules();
        }

        public int NumberOfPlayers { get; private set; }

        public int NumberOfPawns { get; private set; }

        public IStatistic Statistic { get; }

        public IGamePlayer[] Players { get; private set; }

        public GameDirection[] PlayersDirections { get; private set; }

        public string[] PlayersNames { get; private set; }

        public IGameTemplateCreator TemplateCreator { get; private set; }

        public void StartGame()
        {
            var gameTemplate = this.TemplateCreator.CreateTemplate(8, 8, this.Players, this.PlayersDirections);
            var pawnManufacturer = new PawnManufacturer();
            var cellManufacturer = new CellManufacturer(pawnManufacturer);
            var gameBoard = new GameBoard(gameTemplate, cellManufacturer);
            this.engine = new Engine(gameBoard);
            this.engine.Run();
            this.Visible = false;
            var userDesk = new UserDesk(this.engine);
            this.userForm = userDesk;
            userDesk.Visible = true;
            this.engine.GameOverHandler += this.GameOver;
        }

        public void EndGame()
        {

            this.Statistic.SaveStatistic();
            this.Close();
        }

        private void SetStartGameColors()
        {
            this.freeColors = new List<GameColor>();
            this.freeColorsAsString = new List<string>();
            for (int i = 1; i <= NumberOfGameColors; i++)
            {
                this.freeColors.Add((GameColor)i);
                this.freeColorsAsString.Add(((GameColor)i).ToString());
            }
        }

        private void GetPlayerTypes()
        {
            var playerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == "Player");
            this.RaceTypeDictionary["Human"] = playerType;

            var computerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == "AI");
            this.RaceTypeDictionary["Computer"] = computerType;
        }

        private void HideElementsWhenStart()
        {
            this.groupBoxP1.Visible = false;
            this.groupBoxP2.Visible = false;
            this.groupBoxP3.Visible = false;
            this.groupBoxP4.Visible = false;
            this.StartButton.Visible = false;
            this.ExitButton.Visible = false;
            this.ViewScoresButton.Visible = false;

            this.RaceLabel.Visible = false;
            this.RaceComboBox1.Visible = false;
            this.RaceComboBox2.Visible = false;
            this.RaceComboBox3.Visible = false;
            this.RaceComboBox4.Visible = false;
            this.buttonOK1.Visible = false;

            this.NameLabel.Visible = false;
            this.NamePlayer1.Visible = false;
            this.NamePlayer2.Visible = false;
            this.NamePlayer3.Visible = false;
            this.NamePlayer4.Visible = false;
            this.buttonOK2.Visible = false;

            this.ColorLabel.Visible = false;
            this.ColorComboBox1.Visible = false;
            this.ColorComboBox2.Visible = false;
            this.ColorComboBox3.Visible = false;
            this.ColorComboBox4.Visible = false;
            this.buttonOK3.Visible = false;
        }

        private void NumOfPlComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.NumberOfPlayers = int.Parse(this.NumOfPlComboBox.Text[0].ToString());
            bool[] trueArray = new bool[4];
            for (int i = 0; i < this.NumberOfPlayers; i++)
            {
                trueArray[i] = true;
            }

            this.NumOfPlComboBox.Enabled = false;

            this.groupBoxP1.Visible = trueArray[0];
            this.groupBoxP2.Visible = trueArray[1];
            this.groupBoxP3.Visible = trueArray[2];
            this.groupBoxP4.Visible = trueArray[3];

            this.RaceLabel.Visible = true;
            this.RaceComboBox1.Visible = true;
            this.RaceComboBox2.Visible = true;
            this.RaceComboBox3.Visible = true;
            this.RaceComboBox4.Visible = true;
            this.buttonOK1.Visible = true;

            this.Players = new IGamePlayer[this.NumberOfPlayers];
            this.PlayersDirections = new GameDirection[this.NumberOfPlayers];
            this.PlayersNames = new string[this.NumberOfPlayers];
        }

        private void GameOver(object sender, EndGameEventArguments arguments)
        {
            if (arguments.IsGameEnded)
            {
                MessageBox.Show(string.Format("Winner is {0}", arguments.WinnerName));
                this.userForm.Close();
                this.Visible = true;
                this.ExitButton.Visible = true;
                this.StartButton.Visible = true;
                this.ViewScoresButton.Visible = true;
                this.Statistic.SaveResult(this.engine.ActivePlayer.Name, this.engine.GameTurnsCounter);
            }
        }

        private void buttonOK1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.RaceComboBox1.Text) ||
                ((this.RaceComboBox1.Text != "Human") && (this.RaceComboBox1.Text != "Computer")))
            {
                MessageBox.Show("For Player 1 race,  choose one of drop down menu race!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.RaceComboBox2.Text) ||
                ((this.RaceComboBox2.Text != "Human") && (this.RaceComboBox2.Text != "Computer")))
            {
                MessageBox.Show("For Player 2 race, choose one of drop down menu race!");
                return;
            }

            if ((this.NumberOfPlayers > 2) && (string.IsNullOrWhiteSpace(this.RaceComboBox3.Text) ||
                ((this.RaceComboBox3.Text != "Human") && (this.RaceComboBox3.Text != "Computer"))))
            {
                MessageBox.Show("For Player 3 race,  choose one of drop down menu race!");
                return;
            }

            if ((this.NumberOfPlayers > 3) && (string.IsNullOrWhiteSpace(this.RaceComboBox4.Text) ||
                ((this.RaceComboBox4.Text != "Human") && (this.RaceComboBox4.Text != "Computer"))))
            {
                MessageBox.Show("For Player 4 race,  choose one of drop down menu race!");
                return;
            }

            this.RaceComboBox1.Enabled = false;
            this.RaceComboBox2.Enabled = false;
            this.RaceComboBox3.Enabled = false;
            this.RaceComboBox4.Enabled = false;
            this.buttonOK1.Enabled = false;

            this.NameLabel.Visible = true;
            this.NamePlayer1.Visible = true;
            this.NamePlayer2.Visible = true;
            this.NamePlayer3.Visible = true;
            this.NamePlayer4.Visible = true;
            this.buttonOK2.Visible = true;
        }

        private void GetRules()
        {
            using (var reader = new StreamReader(GameConstants.RulesTextPath))
            {
                string line = reader.ReadLine();
                this.rules = line;
            }
        }

        private void CreatePlayer(string playerTypeAsString, int index, GameColor pawnColor)
        {
            if (playerTypeAsString == "Human")
            {
                this.Players[index] = Activator.CreateInstance(this.RaceTypeDictionary[playerTypeAsString], pawnColor) as Player;
            }
            else
            {
                this.Players[index] = Activator.CreateInstance(this.RaceTypeDictionary[playerTypeAsString], pawnColor) as AI;
            }

            if (index == 0)
            {
                this.PlayersDirections[0] = GameDirection.Down;
            }
            else if (index == 1)
            {
                this.PlayersDirections[1] = GameDirection.Up;
            }
            else if (index == 2)
            {
                this.PlayersDirections[2] = GameDirection.Right;
            }
            else if (index == 3)
            {
                this.PlayersDirections[3] = GameDirection.Left;
            }
        }

        private void buttonOK2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.NamePlayer1.Text))
            {
                MessageBox.Show("Enter Name for Player 1!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.NamePlayer2.Text))
            {
                MessageBox.Show("Enter Name for Player 2!");
                return;
            }

            if ((this.NumberOfPlayers > 2) && string.IsNullOrWhiteSpace(this.NamePlayer3.Text))
            {
                MessageBox.Show("Enter Name for Player 3!");
                return;
            }

            if ((this.NumberOfPlayers > 3) && string.IsNullOrWhiteSpace(this.NamePlayer4.Text))
            {
                MessageBox.Show("Enter Name for Player 4!");
                return;
            }

            this.ColorLabel.Visible = true;
            this.ColorComboBox1.Visible = true;
            this.ColorComboBox2.Visible = true;
            this.ColorComboBox3.Visible = true;
            this.ColorComboBox4.Visible = true;
            this.buttonOK3.Visible = true;

            this.NamePlayer1.Enabled = false;
            this.NamePlayer2.Enabled = false;
            this.NamePlayer3.Enabled = false;
            this.NamePlayer4.Enabled = false;
            this.buttonOK2.Enabled = false;
        }

        private void buttonOK3_Click(object sender, EventArgs e)
        {
            if (!this.freeColorsAsString.Contains(this.ColorComboBox1.Text))
            {
                MessageBox.Show("Choose color for Player 1 from drop dawn menu!");
                return;
            }

            if (!this.freeColorsAsString.Contains(this.ColorComboBox2.Text))
            {
                MessageBox.Show("Choose color for Player 2 from drop dawn menu!");
                return;
            }

            if ((this.NumberOfPlayers > 2) && !this.freeColorsAsString.Contains(this.ColorComboBox3.Text))
            {
                MessageBox.Show("Choose color for Player 3 from drop dawn menu!");
                return;
            }

            if ((this.NumberOfPlayers > 3) && !this.freeColorsAsString.Contains(this.ColorComboBox4.Text))
            {
                MessageBox.Show("Choose color for Player 3 from drop dawn menu!");
                return;
            }

            if ((this.ColorComboBox1.Text == this.ColorComboBox2.Text) ||
                ((this.NumberOfPlayers > 2) && (this.ColorComboBox2.Text == this.ColorComboBox3.Text)) ||
                ((this.NumberOfPlayers > 2) && (this.ColorComboBox1.Text == this.ColorComboBox3.Text)) ||
                ((this.NumberOfPlayers > 3) && (this.ColorComboBox3.Text == this.ColorComboBox4.Text)) ||
                ((this.NumberOfPlayers > 3) && (this.ColorComboBox1.Text == this.ColorComboBox4.Text)) ||
                ((this.NumberOfPlayers > 3) && (this.ColorComboBox2.Text == this.ColorComboBox4.Text)))
            {
                MessageBox.Show("Color must be diffrent");
                return;
            }

            int firstIndex = this.freeColorsAsString.IndexOf(this.ColorComboBox1.Text);
            this.CreatePlayer(this.RaceComboBox1.Text, 0, this.freeColors[firstIndex]);
            this.Players[0].Name = this.NamePlayer1.Text;
            int secondIndex = this.freeColorsAsString.IndexOf(this.ColorComboBox2.Text);
            this.CreatePlayer(this.RaceComboBox2.Text, 1, this.freeColors[secondIndex]);
            this.Players[1].Name = this.NamePlayer2.Text;
            if (this.NumberOfPlayers > 2)
            {
                int thirdIndex = this.freeColorsAsString.IndexOf(this.ColorComboBox3.Text);
                this.CreatePlayer(this.RaceComboBox3.Text, 2, this.freeColors[thirdIndex]);
                this.Players[2].Name = this.NamePlayer3.Text;
            }
            if (this.NumberOfPlayers > 3)
            {
                int fourIndex = this.freeColorsAsString.IndexOf(this.ColorComboBox4.Text);
                this.CreatePlayer(this.RaceComboBox4.Text, 3, this.freeColors[fourIndex]);
                this.Players[3].Name = this.NamePlayer4.Text;
            }

            this.StartGame();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.EndGame();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.StartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rulesForn = new Rules(this.rules);
            rulesForn.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var statistic = this.Statistic.GetStatistic();
            var scores = new Scores(statistic);
            scores.Visible = true;
        }
    }
}
