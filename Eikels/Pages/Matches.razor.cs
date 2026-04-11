using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;

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
    }
}
