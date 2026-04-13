using Eikels.Core.Models;

namespace Eikels.Core.Services.Interfaces;

public interface IDataService
{
    Task<string?> GetCurrentEikel();
    Task<List<Match>> GetMatches();
    Task<Player?> GetNextBirtdayPlayer();
    Task<List<Player>> GetPlayers();
}
