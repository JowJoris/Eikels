namespace Eikels.Core.Models
{
    public class Player
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Matches { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int Assists { get; set; } = 0;
        public int ManOfTheMatch { get; set; } = 0;
        public int Eikels { get; set; } = 0;
    }
}
