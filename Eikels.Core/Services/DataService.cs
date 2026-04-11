using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;
using System.Net.Http.Json;

namespace Eikels.Core.Services;

public class DataService : IDataService
{
    private readonly HttpClient _client;
    private List<Match>? Matches;
    public DataService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Match>> GetMatches()
    {
        return Matches ??= await _client.GetFromJsonAsync<List<Match>>("data/matches.json");
    }

    public async Task<Dictionary<string, int>> GetManOfTheMatchList()
    {
        await GetMatches();

        var motmList = new Dictionary<string, int>();

        foreach (var match in Matches)
        {
            foreach (var motm in match.ManOfTheMatch)
            {
                if (!motmList.ContainsKey(motm))
                {
                    motmList.Add(motm, 0);
                }

                motmList[motm] = motmList[motm] + 1;
            }
        }

        return motmList;
    }

    public async Task<Match?> GetNextMatch()
    {
        await GetMatches();

        return Matches.Where(m => m.Date > DateTime.UtcNow.Date.AddDays(-1)).OrderBy(m => m.Date).FirstOrDefault();
    }

    public async Task<string?> GetCurrentEikel()
    {
        await GetMatches();
        return Matches.Where(m => !string.IsNullOrWhiteSpace(m.Eikel)).OrderByDescending(m => m.Date).First().Eikel;
    }
}
