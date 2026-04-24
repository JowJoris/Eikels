using Eikels.Core.Helpers;
using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;
using MudBlazor;

namespace Eikels.Pages
{
    public partial class Dashboard
    {
        private readonly IDataService _dataService;
        public List<Match> Matches { get; set; } = [];
        public Match? LastMatch { get; set; }
        public Match? NextMatch { get; set; }
        public string? CurrentEikel { get; set; }
        public Player? NextBirthdayPlayer { get; set; }

        public Dashboard(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            Matches = await _dataService.GetMatches();
            NextMatch = Matches.Where(m => m.Date > DateTime.UtcNow.AddDays(-1) && string.IsNullOrWhiteSpace(m.Score)).OrderBy(m => m.Date).FirstOrDefault();
            LastMatch = Matches.Where(m => m.Date < DateTime.UtcNow.Date.AddDays(1) && !string.IsNullOrWhiteSpace(m.Score)).OrderByDescending(m => m.Date).FirstOrDefault();
            CurrentEikel = await _dataService.GetCurrentEikel();
            NextBirthdayPlayer = await _dataService.GetNextBirtdayPlayer();
        }

        public static Color GetScoreColor(string score, string location)
        {
            if (string.IsNullOrWhiteSpace(score)) return Color.Default;
            return DataHelper.HasWon(score, location) switch
            {
                DataHelper.ScoreType.WON => Color.Success,
                DataHelper.ScoreType.LOSS => Color.Error,
                _ => Color.Default
            };
        }

        public int[] GetPieChartData()
        {
            var results = new int[] { 0, 0, 0 };
            foreach (var match in Matches.Where(m => !string.IsNullOrWhiteSpace(m.Score)))
            {
                var result = DataHelper.HasWon(match.Score, match.Location);

                switch (result)
                {
                    case DataHelper.ScoreType.WON:
                        results[0]++;
                        break;
                    case DataHelper.ScoreType.DRAW:
                        results[1]++;
                        break;
                    case DataHelper.ScoreType.LOSS:
                        results[2]++;
                        break;
                }
            }

            return results;
        }

        public string[] GetPieChartLabels() => ["Winst", "Gelijk", "Verlies"];
        public string[] GetPieChartColors() => ["LightGreen", "LightGrey", "Red"];
    }
}
