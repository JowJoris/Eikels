using Eikels.Core.Models;

namespace Eikels.Core.Services.Interfaces;

public interface IDataService
{
    Task<List<Match>> GetMatches();

}
