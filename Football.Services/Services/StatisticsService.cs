using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.API.Models;
using Football.Database;
using Football.Services.DTOs;

namespace Football.API.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly FootballContext _footballContext;

        public StatisticsService(FootballContext footballContext) {
            _footballContext = footballContext;
        }

        public async Task<ICollection<YellowCardsDto>> GetYellowCards()
        {
            var yellowCardsPerMatch = Task.Run(() => GetYellowCardsPerMatch());
            return await yellowCardsPerMatch;
        }

        public async Task<ICollection<RedCardsDto>> GetRedCards()
        {
            var redCardsPerMatch = Task.Run(() => GetRedCardsPerMatch());
            return await redCardsPerMatch;
        }

        public async Task<ICollection<MinutesPlayedDto>> GetMinutesPlayed()
        {
            var minutesPlayedPerMatch = Task.Run(() => GetMinutesPlayedPerMatch());
            return await minutesPlayedPerMatch;
        }

        private ICollection<YellowCardsDto> GetYellowCardsPerMatch()
        {
            return GetMatchesWithAllData()
                .AsParallel()
                .Select(m => new YellowCardsDto
                {
                    MatchId = m.Id,
                    YellowCards = SumAllYellowCardsOfMatch(m)
                }).ToList();
        }

        private ICollection<RedCardsDto> GetRedCardsPerMatch()
        {
            return GetMatchesWithAllData()
                .AsParallel()
                .Select(m => new RedCardsDto
                {
                    MatchId = m.Id,
                    RedCards = SumAllRedCardsOfMatch(m)
                }).ToList();
        }

        private ICollection<MinutesPlayedDto> GetMinutesPlayedPerMatch()
        {
            return GetMatchesWithAllData()
                .AsParallel()
                .Select(m => new MinutesPlayedDto
                {
                    MatchId = m.Id,
                    MinutesPlayed = SumAllMinutesPlayedOfMatch(m)
                }).ToList();
        }

        private int SumAllYellowCardsOfMatch(Match match)
        {
            return new List<int>()
            {
                match.HousePlayers.Sum(hp => hp.Player.YellowCard),
                match.AwayPlayers.Sum(ap => ap.Player.YellowCard),
                match.AwayManager.YellowCard,
                match.HouseManager.YellowCard
            }.Sum();
        }

        private int SumAllRedCardsOfMatch(Match match)
        {
            return new List<int>()
            {
                match.HousePlayers.Sum(hp => hp.Player.RedCard),
                match.AwayPlayers.Sum(ap => ap.Player.RedCard),
                match.AwayManager.RedCard,
                match.HouseManager.RedCard
            }.Sum();
        }

        private int SumAllMinutesPlayedOfMatch(Match match)
        {
            return new List<int>()
            {
                match.HousePlayers.Sum(hp => hp.Player.MinutesPlayed),
                match.AwayPlayers.Sum(ap => ap.Player.MinutesPlayed),
            }.Sum();
        }

        private IQueryable<Match> GetMatchesWithAllData()
        {
            return _footballContext.Matches
                .Include(m => m.AwayPlayers)
                .ThenInclude(ap => ap.Player)
                .Include(m => m.HousePlayers)
                .ThenInclude(hp => hp.Player)
                .Include(m => m.HouseManager)
                .Include(m => m.AwayManager);
        }
    }
}
