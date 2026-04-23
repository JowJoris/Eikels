namespace Eikels.Core.Models
{
    public class Match
    {
        public string Opponent { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<string> Players { get; set; } = [];
        public string Score { get; set; }
        public string Eikel { get; set; }
        public string Type { get; set; }
        public List<string> ManOfTheMatch { get; set; } = [];
        public List<GoalScorer> GoalScorers { get; set; } = [];

        public class GoalScorer
        {
            public string Name { get; set; }
            public string? Assist { get; set; }
            public int? Minute { get; set; }

        }
    }
}
