using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;

namespace Eikels.Pages
{
    public partial class Players
    {
        private readonly IDataService _dataService;
        public List<Player> PlayerList { get; set; } = [];
        public List<Match> MatchLists { get; set; } = [];

        public Players(IDataService dataService)
        {
            _dataService = dataService;
        }

        protected override async Task OnInitializedAsync()
        {
            var matchList = await _dataService.GetMatches();

            foreach (var match in matchList.Where(m => !string.IsNullOrWhiteSpace(m.Score)))
            {
                foreach (var playerName in match.Players)
                {
                    var player = PlayerList.SingleOrDefault(p => p.Name == playerName);
                    if (player == null)
                    {
                        player = new Player() { Name = playerName };
                        PlayerList.Add(player);
                    }

                    player.Matches++;

                    player.Goals += match.GoalScorers.Count(gs => gs.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
                    player.Assists += match.GoalScorers.Count(gs => !string.IsNullOrWhiteSpace(gs.Assist) && gs.Assist.Equals(playerName, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var motm in match.ManOfTheMatch)
                {
                    var player = PlayerList.SingleOrDefault(p => p.Name == motm);
                    if (player == null)
                    {
                        player = new Player() { Name = motm };
                        PlayerList.Add(player);
                    }
                    player.ManOfTheMatch++;
                }

                if (!string.IsNullOrWhiteSpace(match.Eikel))
                {
                    var player = PlayerList.SingleOrDefault(p => p.Name == match.Eikel);
                    if (player == null)
                    {
                        player = new Player() { Name = match.Eikel };
                        PlayerList.Add(player);
                    }
                    player.Eikels++;
                }
            }
        }
    }
}
