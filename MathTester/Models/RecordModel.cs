using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTester.Models
{
    public class RecordModel
    {
        public Enums.GameMode GameMode { get; set; }
        public Enums.Difficulty Difficulty { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
