namespace Chess.UI
{
    using System;

    using System.Windows.Forms;

    public partial class Scores : Form
    {
        public Scores(string text)
        {
            this.InitializeComponent();
            this.richTextBox1.Text = text;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
