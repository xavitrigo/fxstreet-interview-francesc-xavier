using Football.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public interface IMatchService
    {
        Task<ICollection<MatchDto>> GetAllMatchs();
        Task<MatchDto> GetMatchById(int id);
        Task<MatchDto> AddMatch(MatchDto newMatch);
        Task<MatchDto> UpdateMatch(int id, MatchDto newMatch);
        Task<bool> MatchExistsInDb(int id);
    }
}
