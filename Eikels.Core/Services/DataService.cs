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
}
