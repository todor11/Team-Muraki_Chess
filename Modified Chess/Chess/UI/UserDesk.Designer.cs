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
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // boardImage
            // 
            this.boardImage.BackgroundImage = global::Chess.Properties.Resources.chessboard;
            this.boardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boardImage.Location = new System.Drawing.Point(50, 50);
            this.boardImage.Name = "boardImage";
            this.boardImage.Size = new System.Drawing.Size(596, 569);
            this.boardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boardImage.TabIndex = 0;
            this.boardImage.TabStop = false;
            // 
            // UserDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 666);
            this.Controls.Add(this.boardImage);
            this.Name = "UserDesk";
            this.Text = "UserDesk";
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
    }
}