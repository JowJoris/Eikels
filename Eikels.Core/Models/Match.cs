namespace Eikels.Core.Models
{
    public class Match
    {
        public string Opponent { get; set; }
        public string Location { get; set; }
        public DateOnly Date { get; set; }
        public List<string> Players { get; set; }
        public string Score { get; set; }
        public string Eikel { get; set; }
        public string Type { get; set; }
        public List<string> ManOfTheMatch { get; set; }
    }
}
