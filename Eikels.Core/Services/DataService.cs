using Eikels.Core.Models;
using Eikels.Core.Services.Interfaces;
using System.Net.Http.Json;

namespace Eikels.Core.Services;

public class DataService : IDataService
{
    private readonly HttpClient _client;
    private List<Match>? Matches;
    private List<Player>? Players;
    public DataService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Match>> GetMatches()
    {
        return Matches ??= await _client.GetFromJsonAsync<List<Match>>("data/matches.json");
    }

    public async Task<List<Player>> GetPlayers()
    {
        return Players ??= await _client.GetFromJsonAsync<List<Player>>("data/players.json");
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

    public async Task<Player?> GetNextBirtdayPlayer()
    {
        await GetPlayers();
        return Players.Where(p => !IsBeforeNow(p.Birthday)).OrderBy(p => p.Birthday.Month).ThenBy(p => p.Birthday.Day).First();

        static bool IsBeforeNow(DateTime dateTime)
        {
            return dateTime.Month < DateTime.Now.Month
                || (dateTime.Month == DateTime.Now.Month && dateTime.Day < DateTime.Now.Day);
        }
    }
}
