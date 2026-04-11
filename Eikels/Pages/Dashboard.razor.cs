using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;

namespace Eikels.Pages
{
    public partial class Dashboard
    {
        private readonly IDataService _dataService;
        public Match? NextMatch { get; set; }
        public string? CurrentEikel { get; set; }
        public Dictionary<string, int> ManOfTheMatchList { get; set; } = [];
        public Dashboard(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            ManOfTheMatchList = await _dataService.GetManOfTheMatchList();
            NextMatch = await _dataService.GetNextMatch();
            CurrentEikel = await _dataService.GetCurrentEikel();

        }
    }
}
