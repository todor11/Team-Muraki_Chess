using System;
namespace Chess.UI
{
    using System.Windows.Forms;

    public partial class Scores : Form
    {
        public Scores(string text)
        {
            InitializeComponent();
            this.richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
