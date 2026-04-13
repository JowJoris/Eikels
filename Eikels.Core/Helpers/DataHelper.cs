namespace Eikels.Core.Helpers
{
    public static class DataHelper
    {
        public static bool? HasWon(string score, string location)
        {
            var split = score.Split('-');
            var homeScore = int.Parse(split[0]);
            var awayScore = int.Parse(split[1]);

            if (homeScore == awayScore) return null;

            if (location.Equals("Thuis", StringComparison.OrdinalIgnoreCase))
                return homeScore > awayScore;
            if (location.Equals("Uit", StringComparison.OrdinalIgnoreCase))
                return homeScore < awayScore;

            return null;

        }
    }
}
