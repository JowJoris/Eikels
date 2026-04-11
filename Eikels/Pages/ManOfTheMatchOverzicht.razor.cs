using Eikels.Core.Services.Interfaces;

namespace Eikels.Pages
{
    public partial class ManOfTheMatchOverzicht
    {
        private readonly IDataService _dataService;
        public Dictionary<string, int> ManOfTheMatchList { get; set; } = [];
        public ManOfTheMatchOverzicht(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            var matches = await _dataService.GetMatches();
            ManOfTheMatchList = await _dataService.GetManOfTheMatchList();
        }
    }
}
