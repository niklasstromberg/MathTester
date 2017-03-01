using MathTester.Models;
using System.Collections.Generic;
using System.Linq;

namespace MathTester
{
    internal class RecordHandler
    {
        private List<RecordModel> Records { get; set; }

        public bool IsHighscore(Enums.GameMode gameMode, int score, Enums.Difficulty difficulty)
        {
            var highscores = from record in Records.OrderBy(x => x.Score)
                             where record.GameMode == gameMode && record.Difficulty == difficulty
                             select record;
            var lowest = highscores.LastOrDefault();
            if (lowest.Score < score)
                return true;
            return false;
        }

        public List<RecordModel> GetTopThree(Enums.GameMode gameMode, Enums.Difficulty difficulty)
        {
            List<RecordModel> topThree = new List<RecordModel>();
            var query = from record in Records.OrderBy(x => x.Score)
                        where record.GameMode == gameMode && record.Difficulty == difficulty
                        select record as RecordModel;
            while (topThree.Count < 4)
            {
                foreach (var record in query)
                {
                    topThree.Add(record);
                }
            }
            return topThree;
        }

        public void InsertHighscore(RecordModel record)
        {
            Records.Add(record);
        }
    }
}
