namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Utilities;

    public class Statistic : IStatistic
    {
        private readonly IList<IGameResult> topResults;
         
        public Statistic()
        {
            this.topResults = new List<IGameResult>();
            this.FillStatistic();
        }

        public IEnumerable<IGameResult> TopResults { get; private set; }

        public string GetStatistic()
        {
            StringBuilder results = new StringBuilder();
            foreach (var score in this.topResults.OrderBy(n => n.NumberOfMoves))
            {
                results.AppendLine(score.ToString() + "moves");
            }

            return results.ToString();
        }

        public void SaveResult(string name, int result)
        {
            this.topResults.Add(new GameResult(name, result));
        }

        public void SaveStatistic()
        {
            using (var writer = new StreamWriter(GameConstants.StatisticPath))
            {
                var newStatistic = this.topResults.OrderBy(n => n.NumberOfMoves).ToArray();
                int maxResults = 10;
                if (newStatistic.Length < 10)
                {
                    maxResults = newStatistic.Length;
                }

                for (int i = 0; i < maxResults; i++)
                {
                    writer.WriteLine(newStatistic[i]);
                }
            }
        }

        private void FillStatistic()
        {
            using (var reader = new StreamReader(GameConstants.StatisticPath))
            {
                string line = string.Empty;
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] result = line.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    this.topResults.Add(new GameResult(result[0], int.Parse(result[1])));
                }
            }
        }
    }
}
