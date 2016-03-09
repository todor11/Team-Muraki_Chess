namespace Chess.UI
{
    public partial class UserDesk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox boardImage;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.boardImage = new System.Windows.Forms.PictureBox();
            this.PlayerNamelabel1 = new System.Windows.Forms.Label();
            this.PlayerNamelabel2 = new System.Windows.Forms.Label();
            this.PlayerNamelabel4 = new System.Windows.Forms.Label();
            this.PlayerNamelabel3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // boardImage
            // 
            this.boardImage.BackgroundImage = global::Chess.Properties.Resources.chessboard;
            this.boardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boardImage.Location = new System.Drawing.Point(150, 35);
            this.boardImage.Name = "boardImage";
            this.boardImage.Size = new System.Drawing.Size(600, 600);
            this.boardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boardImage.TabIndex = 0;
            this.boardImage.TabStop = false;
            // 
            // PlayerNamelabel1
            // 
            this.PlayerNamelabel1.AutoSize = true;
            this.PlayerNamelabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNamelabel1.Location = new System.Drawing.Point(396, 9);
            this.PlayerNamelabel1.Name = "PlayerNamelabel1";
            this.PlayerNamelabel1.Size = new System.Drawing.Size(51, 16);
            this.PlayerNamelabel1.TabIndex = 2;
            this.PlayerNamelabel1.Text = "label1";
            // 
            // PlayerNamelabel2
            // 
            this.PlayerNamelabel2.AutoSize = true;
            this.PlayerNamelabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNamelabel2.Location = new System.Drawing.Point(396, 641);
            this.PlayerNamelabel2.Name = "PlayerNamelabel2";
            this.PlayerNamelabel2.Size = new System.Drawing.Size(51, 16);
            this.PlayerNamelabel2.TabIndex = 3;
            this.PlayerNamelabel2.Text = "label1";
            // 
            // PlayerNamelabel4
            // 
            this.PlayerNamelabel4.AutoSize = true;
            this.PlayerNamelabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNamelabel4.Location = new System.Drawing.Point(756, 322);
            this.PlayerNamelabel4.Name = "PlayerNamelabel4";
            this.PlayerNamelabel4.Size = new System.Drawing.Size(51, 16);
            this.PlayerNamelabel4.TabIndex = 4;
            this.PlayerNamelabel4.Text = "label2";
            // 
            // PlayerNamelabel3
            // 
            this.PlayerNamelabel3.AutoSize = true;
            this.PlayerNamelabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNamelabel3.Location = new System.Drawing.Point(12, 322);
            this.PlayerNamelabel3.Name = "PlayerNamelabel3";
            this.PlayerNamelabel3.Size = new System.Drawing.Size(51, 16);
            this.PlayerNamelabel3.TabIndex = 5;
            this.PlayerNamelabel3.Text = "label3";
            // 
            // UserDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 666);
            this.Controls.Add(this.PlayerNamelabel3);
            this.Controls.Add(this.PlayerNamelabel4);
            this.Controls.Add(this.PlayerNamelabel2);
            this.Controls.Add(this.PlayerNamelabel1);
            this.Controls.Add(this.boardImage);
            this.Name = "UserDesk";
            this.Text = "UserDesk";
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label PlayerNamelabel1;
        private System.Windows.Forms.Label PlayerNamelabel2;
        private System.Windows.Forms.Label PlayerNamelabel4;
        private System.Windows.Forms.Label PlayerNamelabel3;
    }
}