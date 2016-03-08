namespace Chess.Core
{
    partial class FormGameCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK3 = new System.Windows.Forms.Button();
            this.buttonOK2 = new System.Windows.Forms.Button();
            this.buttonOK1 = new System.Windows.Forms.Button();
            this.groupBoxP4 = new System.Windows.Forms.GroupBox();
            this.ColorComboBox4 = new System.Windows.Forms.ComboBox();
            this.NamePlayer4 = new System.Windows.Forms.TextBox();
            this.RaceComboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBoxP3 = new System.Windows.Forms.GroupBox();
            this.ColorComboBox3 = new System.Windows.Forms.ComboBox();
            this.NamePlayer3 = new System.Windows.Forms.TextBox();
            this.RaceComboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBoxP2 = new System.Windows.Forms.GroupBox();
            this.ColorComboBox2 = new System.Windows.Forms.ComboBox();
            this.NamePlayer2 = new System.Windows.Forms.TextBox();
            this.RaceComboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBoxP1 = new System.Windows.Forms.GroupBox();
            this.RaceComboBox1 = new System.Windows.Forms.ComboBox();
            this.ColorComboBox1 = new System.Windows.Forms.ComboBox();
            this.NamePlayer1 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.RaceLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NumOfPlComboBox = new System.Windows.Forms.ComboBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.NumOfPlLabel = new System.Windows.Forms.Label();
            this.groupBoxP4.SuspendLayout();
            this.groupBoxP3.SuspendLayout();
            this.groupBoxP2.SuspendLayout();
            this.groupBoxP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK3
            // 
            this.buttonOK3.Location = new System.Drawing.Point(690, 232);
            this.buttonOK3.Name = "buttonOK3";
            this.buttonOK3.Size = new System.Drawing.Size(47, 23);
            this.buttonOK3.TabIndex = 54;
            this.buttonOK3.Text = "OK";
            this.buttonOK3.UseVisualStyleBackColor = true;
            this.buttonOK3.Click += new System.EventHandler(this.buttonOK3_Click);
            // 
            // buttonOK2
            // 
            this.buttonOK2.Location = new System.Drawing.Point(689, 187);
            this.buttonOK2.Name = "buttonOK2";
            this.buttonOK2.Size = new System.Drawing.Size(47, 23);
            this.buttonOK2.TabIndex = 53;
            this.buttonOK2.Text = "OK";
            this.buttonOK2.UseVisualStyleBackColor = true;
            this.buttonOK2.Click += new System.EventHandler(this.buttonOK2_Click);
            // 
            // buttonOK1
            // 
            this.buttonOK1.Location = new System.Drawing.Point(690, 145);
            this.buttonOK1.Name = "buttonOK1";
            this.buttonOK1.Size = new System.Drawing.Size(47, 23);
            this.buttonOK1.TabIndex = 52;
            this.buttonOK1.Text = "OK";
            this.buttonOK1.UseVisualStyleBackColor = true;
            this.buttonOK1.Click += new System.EventHandler(this.buttonOK1_Click);
            // 
            // groupBoxP4
            // 
            this.groupBoxP4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxP4.Controls.Add(this.ColorComboBox4);
            this.groupBoxP4.Controls.Add(this.NamePlayer4);
            this.groupBoxP4.Controls.Add(this.RaceComboBox4);
            this.groupBoxP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxP4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxP4.Location = new System.Drawing.Point(548, 112);
            this.groupBoxP4.Name = "groupBoxP4";
            this.groupBoxP4.Size = new System.Drawing.Size(135, 160);
            this.groupBoxP4.TabIndex = 49;
            this.groupBoxP4.TabStop = false;
            this.groupBoxP4.Text = "Player 4 :";
            // 
            // ColorComboBox4
            // 
            this.ColorComboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorComboBox4.FormattingEnabled = true;
            this.ColorComboBox4.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Yellow"});
            this.ColorComboBox4.Location = new System.Drawing.Point(7, 120);
            this.ColorComboBox4.Name = "ColorComboBox4";
            this.ColorComboBox4.Size = new System.Drawing.Size(122, 24);
            this.ColorComboBox4.TabIndex = 9;
            // 
            // NamePlayer4
            // 
            this.NamePlayer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayer4.Location = new System.Drawing.Point(6, 76);
            this.NamePlayer4.Name = "NamePlayer4";
            this.NamePlayer4.Size = new System.Drawing.Size(121, 22);
            this.NamePlayer4.TabIndex = 14;
            // 
            // RaceComboBox4
            // 
            this.RaceComboBox4.FormattingEnabled = true;
            this.RaceComboBox4.Items.AddRange(new object[] {
            "Human",
            "Computer"});
            this.RaceComboBox4.Location = new System.Drawing.Point(6, 33);
            this.RaceComboBox4.Name = "RaceComboBox4";
            this.RaceComboBox4.Size = new System.Drawing.Size(121, 24);
            this.RaceComboBox4.TabIndex = 15;
            // 
            // groupBoxP3
            // 
            this.groupBoxP3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxP3.Controls.Add(this.ColorComboBox3);
            this.groupBoxP3.Controls.Add(this.NamePlayer3);
            this.groupBoxP3.Controls.Add(this.RaceComboBox3);
            this.groupBoxP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxP3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxP3.Location = new System.Drawing.Point(400, 112);
            this.groupBoxP3.Name = "groupBoxP3";
            this.groupBoxP3.Size = new System.Drawing.Size(135, 160);
            this.groupBoxP3.TabIndex = 50;
            this.groupBoxP3.TabStop = false;
            this.groupBoxP3.Text = "Player 3 :";
            // 
            // ColorComboBox3
            // 
            this.ColorComboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorComboBox3.FormattingEnabled = true;
            this.ColorComboBox3.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Yellow"});
            this.ColorComboBox3.Location = new System.Drawing.Point(7, 120);
            this.ColorComboBox3.Name = "ColorComboBox3";
            this.ColorComboBox3.Size = new System.Drawing.Size(122, 24);
            this.ColorComboBox3.TabIndex = 9;
            // 
            // NamePlayer3
            // 
            this.NamePlayer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayer3.Location = new System.Drawing.Point(6, 76);
            this.NamePlayer3.Name = "NamePlayer3";
            this.NamePlayer3.Size = new System.Drawing.Size(121, 22);
            this.NamePlayer3.TabIndex = 14;
            // 
            // RaceComboBox3
            // 
            this.RaceComboBox3.FormattingEnabled = true;
            this.RaceComboBox3.Items.AddRange(new object[] {
            "Human",
            "Computer"});
            this.RaceComboBox3.Location = new System.Drawing.Point(6, 33);
            this.RaceComboBox3.Name = "RaceComboBox3";
            this.RaceComboBox3.Size = new System.Drawing.Size(121, 24);
            this.RaceComboBox3.TabIndex = 15;
            // 
            // groupBoxP2
            // 
            this.groupBoxP2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxP2.Controls.Add(this.ColorComboBox2);
            this.groupBoxP2.Controls.Add(this.NamePlayer2);
            this.groupBoxP2.Controls.Add(this.RaceComboBox2);
            this.groupBoxP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxP2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxP2.Location = new System.Drawing.Point(252, 112);
            this.groupBoxP2.Name = "groupBoxP2";
            this.groupBoxP2.Size = new System.Drawing.Size(135, 160);
            this.groupBoxP2.TabIndex = 51;
            this.groupBoxP2.TabStop = false;
            this.groupBoxP2.Text = "Player 2 :";
            // 
            // ColorComboBox2
            // 
            this.ColorComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorComboBox2.FormattingEnabled = true;
            this.ColorComboBox2.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Yellow"});
            this.ColorComboBox2.Location = new System.Drawing.Point(7, 120);
            this.ColorComboBox2.Name = "ColorComboBox2";
            this.ColorComboBox2.Size = new System.Drawing.Size(122, 24);
            this.ColorComboBox2.TabIndex = 9;
            // 
            // NamePlayer2
            // 
            this.NamePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayer2.Location = new System.Drawing.Point(6, 76);
            this.NamePlayer2.Name = "NamePlayer2";
            this.NamePlayer2.Size = new System.Drawing.Size(121, 22);
            this.NamePlayer2.TabIndex = 14;
            // 
            // RaceComboBox2
            // 
            this.RaceComboBox2.FormattingEnabled = true;
            this.RaceComboBox2.Items.AddRange(new object[] {
            "Human",
            "Computer"});
            this.RaceComboBox2.Location = new System.Drawing.Point(6, 33);
            this.RaceComboBox2.Name = "RaceComboBox2";
            this.RaceComboBox2.Size = new System.Drawing.Size(121, 24);
            this.RaceComboBox2.TabIndex = 15;
            // 
            // groupBoxP1
            // 
            this.groupBoxP1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxP1.Controls.Add(this.RaceComboBox1);
            this.groupBoxP1.Controls.Add(this.ColorComboBox1);
            this.groupBoxP1.Controls.Add(this.NamePlayer1);
            this.groupBoxP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxP1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxP1.Location = new System.Drawing.Point(106, 112);
            this.groupBoxP1.Name = "groupBoxP1";
            this.groupBoxP1.Size = new System.Drawing.Size(140, 160);
            this.groupBoxP1.TabIndex = 48;
            this.groupBoxP1.TabStop = false;
            this.groupBoxP1.Text = "Player 1 :";
            // 
            // RaceComboBox1
            // 
            this.RaceComboBox1.FormattingEnabled = true;
            this.RaceComboBox1.Items.AddRange(new object[] {
            "Human",
            "Computer"});
            this.RaceComboBox1.Location = new System.Drawing.Point(8, 33);
            this.RaceComboBox1.Name = "RaceComboBox1";
            this.RaceComboBox1.Size = new System.Drawing.Size(121, 24);
            this.RaceComboBox1.TabIndex = 16;
            // 
            // ColorComboBox1
            // 
            this.ColorComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorComboBox1.FormattingEnabled = true;
            this.ColorComboBox1.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Yellow"});
            this.ColorComboBox1.Location = new System.Drawing.Point(7, 120);
            this.ColorComboBox1.Name = "ColorComboBox1";
            this.ColorComboBox1.Size = new System.Drawing.Size(122, 24);
            this.ColorComboBox1.TabIndex = 9;
            // 
            // NamePlayer1
            // 
            this.NamePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePlayer1.Location = new System.Drawing.Point(6, 76);
            this.NamePlayer1.Name = "NamePlayer1";
            this.NamePlayer1.Size = new System.Drawing.Size(121, 22);
            this.NamePlayer1.TabIndex = 14;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(242, 289);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(200, 26);
            this.StartButton.TabIndex = 47;
            this.StartButton.Text = "Start game";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLabel.Location = new System.Drawing.Point(46, 238);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(53, 18);
            this.ColorLabel.TabIndex = 46;
            this.ColorLabel.Text = "Color :";
            this.ColorLabel.UseWaitCursor = true;
            // 
            // RaceLabel
            // 
            this.RaceLabel.AutoSize = true;
            this.RaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaceLabel.Location = new System.Drawing.Point(46, 144);
            this.RaceLabel.Name = "RaceLabel";
            this.RaceLabel.Size = new System.Drawing.Size(51, 18);
            this.RaceLabel.TabIndex = 45;
            this.RaceLabel.Text = "Race :";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(45, 188);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(56, 18);
            this.NameLabel.TabIndex = 44;
            this.NameLabel.Text = "Name :";
            // 
            // NumOfPlComboBox
            // 
            this.NumOfPlComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfPlComboBox.FormattingEnabled = true;
            this.NumOfPlComboBox.Items.AddRange(new object[] {
            "2 players",
            "3 players",
            "4 players"});
            this.NumOfPlComboBox.Location = new System.Drawing.Point(413, 74);
            this.NumOfPlComboBox.Name = "NumOfPlComboBox";
            this.NumOfPlComboBox.Size = new System.Drawing.Size(122, 24);
            this.NumOfPlComboBox.TabIndex = 43;
            this.NumOfPlComboBox.SelectedIndexChanged += new System.EventHandler(this.NumOfPlComboBox_SelectedIndexChanged);
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabel.Location = new System.Drawing.Point(279, 29);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(153, 24);
            this.MainLabel.TabIndex = 42;
            this.MainLabel.Text = "Game manager";
            // 
            // NumOfPlLabel
            // 
            this.NumOfPlLabel.AutoSize = true;
            this.NumOfPlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfPlLabel.Location = new System.Drawing.Point(196, 75);
            this.NumOfPlLabel.Name = "NumOfPlLabel";
            this.NumOfPlLabel.Size = new System.Drawing.Size(191, 18);
            this.NumOfPlLabel.TabIndex = 41;
            this.NumOfPlLabel.Text = "Choose number of players :";
            // 
            // FormGameCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 344);
            this.Controls.Add(this.buttonOK3);
            this.Controls.Add(this.buttonOK2);
            this.Controls.Add(this.buttonOK1);
            this.Controls.Add(this.groupBoxP4);
            this.Controls.Add(this.groupBoxP3);
            this.Controls.Add(this.groupBoxP2);
            this.Controls.Add(this.groupBoxP1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.RaceLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NumOfPlComboBox);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.NumOfPlLabel);
            this.Name = "FormGameCreator";
            this.Text = "FormGameCreator";
            this.groupBoxP4.ResumeLayout(false);
            this.groupBoxP4.PerformLayout();
            this.groupBoxP3.ResumeLayout(false);
            this.groupBoxP3.PerformLayout();
            this.groupBoxP2.ResumeLayout(false);
            this.groupBoxP2.PerformLayout();
            this.groupBoxP1.ResumeLayout(false);
            this.groupBoxP1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK3;
        private System.Windows.Forms.Button buttonOK2;
        private System.Windows.Forms.Button buttonOK1;
        private System.Windows.Forms.GroupBox groupBoxP4;
        private System.Windows.Forms.ComboBox ColorComboBox4;
        private System.Windows.Forms.TextBox NamePlayer4;
        private System.Windows.Forms.ComboBox RaceComboBox4;
        private System.Windows.Forms.GroupBox groupBoxP3;
        private System.Windows.Forms.ComboBox ColorComboBox3;
        private System.Windows.Forms.TextBox NamePlayer3;
        private System.Windows.Forms.ComboBox RaceComboBox3;
        private System.Windows.Forms.GroupBox groupBoxP2;
        private System.Windows.Forms.ComboBox ColorComboBox2;
        private System.Windows.Forms.TextBox NamePlayer2;
        private System.Windows.Forms.ComboBox RaceComboBox2;
        private System.Windows.Forms.GroupBox groupBoxP1;
        private System.Windows.Forms.ComboBox RaceComboBox1;
        private System.Windows.Forms.ComboBox ColorComboBox1;
        private System.Windows.Forms.TextBox NamePlayer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label RaceLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ComboBox NumOfPlComboBox;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Label NumOfPlLabel;
    }
}