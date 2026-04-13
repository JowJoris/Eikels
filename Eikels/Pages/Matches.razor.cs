using Eikels.Core.Helpers;
using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;
using MudBlazor;

namespace Eikels.Pages
{
    public partial class Matches
    {
        private readonly IDataService _dataService;
        public List<Match> MatchList { get; set; } = [];
        public Matches(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            MatchList = await _dataService.GetMatches();
        }

        public static Color GetScoreColor(string score, string location)
        {
            if (string.IsNullOrWhiteSpace(score)) return Color.Default;
            return DataHelper.HasWon(score, location) switch
            {
                true => Color.Success,
                false => Color.Error,
                _ => Color.Default
            };
        }
    }
}
