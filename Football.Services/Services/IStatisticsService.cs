using Football.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Services
{
    public interface IStatisticsService
    {
        Task<ICollection<YellowCardsDto>> GetYellowCards();
        Task<ICollection<RedCardsDto>> GetRedCards();
        Task<ICollection<MinutesPlayedDto>> GetMinutesPlayed();
    }
}
