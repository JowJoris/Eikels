namespace Eikels.Core.Helpers
{
    public static class DataHelper
    {
        public static ScoreType HasWon(string score, string location)
        {
            var split = score.Split('-');
            var homeScore = int.Parse(split[0]);
            var awayScore = int.Parse(split[1]);

            if (homeScore == awayScore) return ScoreType.DRAW;

            if (location.Equals("Thuis", StringComparison.OrdinalIgnoreCase))
                return homeScore > awayScore ? ScoreType.WON : ScoreType.LOSS;
            if (location.Equals("Uit", StringComparison.OrdinalIgnoreCase))
                return homeScore < awayScore ? ScoreType.WON : ScoreType.LOSS;

            return ScoreType.DRAW;

        }

        public static int GetScoredGoals(string score, string location)
        {
            var split = score.Split('-');
            var homeScore = int.Parse(split[0]);
            var awayScore = int.Parse(split[1]);

            return location.Equals("Thuis", StringComparison.OrdinalIgnoreCase) ? homeScore : awayScore;
        }

        public enum ScoreType
        {
            WON,
            LOSS,
            DRAW
        }
    }
}
