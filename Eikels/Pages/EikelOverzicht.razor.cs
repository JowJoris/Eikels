using Eikels.Core.Services.Interfaces;

namespace Eikels.Pages
{
    public partial class EikelOverzicht
    {
        private readonly IDataService _dataService;
        public Dictionary<string, int> EikelList { get; set; } = [];
        public EikelOverzicht(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            var matches = await _dataService.GetMatches();
            EikelList = await _dataService.GetEikelList();
        }
    }
}
