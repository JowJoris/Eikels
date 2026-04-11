using Eikels.Core.Models;

namespace Eikels.Core.Services.Interfaces;

public interface IDataService
{
    Task<string?> GetCurrentEikel();
    Task<Dictionary<string, int>> GetEikelList();
    Task<Dictionary<string, int>> GetManOfTheMatchList();
    Task<List<Match>> GetMatches();
    Task<Player?> GetNextBirtdayPlayer();
    Task<Match?> GetNextMatch();
    Task<List<Player>> GetPlayers();
}
