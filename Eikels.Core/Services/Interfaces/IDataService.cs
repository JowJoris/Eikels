using Eikels.Core.Models;

namespace Eikels.Core.Services.Interfaces;

public interface IDataService
{
    Task<string?> GetCurrentEikel();
    Task<Dictionary<string, int>> GetManOfTheMatchList();
    Task<List<Match>> GetMatches();
    Task<Match?> GetNextMatch();
}
