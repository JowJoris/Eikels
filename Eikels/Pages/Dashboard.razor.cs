using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;

namespace Eikels.Pages
{
    public partial class Dashboard
    {
        private readonly IDataService _dataService;
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
            var matches = await _dataService.GetMatches();
            NextMatch = matches.Where(m => m.Date > DateTime.UtcNow.AddDays(-1) && string.IsNullOrWhiteSpace(m.Score)).OrderBy(m => m.Date).FirstOrDefault();
            LastMatch = matches.Where(m => m.Date < DateTime.UtcNow.Date.AddDays(1) && !string.IsNullOrWhiteSpace(m.Score)).OrderByDescending(m => m.Date).FirstOrDefault();
            CurrentEikel = await _dataService.GetCurrentEikel();
            NextBirthdayPlayer = await _dataService.GetNextBirtdayPlayer();
        }
    }
}
