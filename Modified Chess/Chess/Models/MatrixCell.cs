namespace Chess.Models
{
    using System.Text;

    using Chess.Contracts;

    public class MatrixCell : IMatrixCell
    {
        private StringBuilder roadToFinal;
        public MatrixCell(int row, int col, int step, string roadToFinal)
        {
            this.Row = row;
            this.Col = col;
            this.Step = step;
            this.roadToFinal = new StringBuilder();
            this.RoadToFinal = roadToFinal;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Step { get; set; }

        public string RoadToFinal
        {
            get
            {
                return this.roadToFinal.ToString();
            }

            set
            {
                this.roadToFinal.Append(value + this.Row + "," + this.Col + ";");
            }
        }
    }
}
