using MathTester.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathTester
{
    public class RecordHandler
    {
        private List<RecordModel> Records = new List<RecordModel>();

        public RecordHandler()
        {
            var fileHandler = new FileHandler();
            if (fileHandler.FileExists())
                Records = fileHandler.Read();
        }

        public List<RecordModel> GetRecordsToSave()
        {
            List<RecordModel> result = new List<RecordModel>();
            var modes = Enum.GetValues(typeof(Enums.GameMode));
            var difficulties = Enum.GetValues(typeof(Enums.Difficulty));
            foreach(var mode in modes)
            {
                foreach(var difficulty in difficulties)
                {
                    var topThree = GetTopThree((Enums.GameMode)mode, (Enums.Difficulty)difficulty);
                    result.AddRange(topThree);
                }
            }
            return result;
        }

        public bool IsHighscore(RecordModel input)
        {
            var highscores = from record in Records.OrderBy(x => x.Score)
                             where record.GameMode == input.GameMode && record.Difficulty == input.Difficulty
                             select record;
            if (highscores.Any())
            {
                var lowest = highscores.LastOrDefault();
                if (lowest.Score < input.Score)
                    return true;
                return false;
            }
            return true;
        }

        public IEnumerable<RecordModel> GetTopThree(Enums.GameMode gameMode, Enums.Difficulty difficulty)
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
                if (topThree.Count == query.Count())
                    break;
            }
            return topThree.OrderByDescending(x => x.Score);
        }

        public void InsertHighscore(RecordModel record)
        {
            Records.Add(record);
        }
    }
}
