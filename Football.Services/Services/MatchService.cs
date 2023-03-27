using AutoMapper;
using Football.API.Models;
using Football.Database;
using Football.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public class MatchService : IMatchService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MatchService> _logger;

        public MatchService(
            FootballContext footballContext,
            IMapper mapper,
            ILogger<MatchService> logger
        ) {
            _footballContext = footballContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<MatchDto>> GetAllMatchs()
        {
            var Matchs = await GetMatchesWithAllData()
                .Select(m => _mapper.Map<MatchDto>(m))
                .ToListAsync();
            return Matchs;
        }

        public async Task<MatchDto> GetMatchById(int id)
        {
            var match = await GetMatchesWithAllData()
                .AsNoTracking() //Detatch the entity so when it's getted, you can updated it
                .FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<MatchDto>(match);
        }

        public async Task<MatchDto> AddMatch(MatchDto newMatch)
        {
            var parsedMatch = _mapper.Map<Match>(newMatch);
            parsedMatch.Id = 0; //ID will be setted automatically 

            var matchInDb = await _footballContext.Matches.AddAsync(parsedMatch);
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Created Match with ID ${matchInDb.Entity.Id}");
                return _mapper.Map<MatchDto>(matchInDb.Entity);
            }

            _logger.LogError($"Couldn't create Match with ID ${matchInDb.Entity.Id}");
            return null;
        }

        public async Task<MatchDto> UpdateMatch(int id, MatchDto newMatch)
        {
            var parsedMatch = _mapper.Map<Match>(newMatch);
            parsedMatch.Id = id; //To make sure the right entity is updated

            var matchInDb = _footballContext.Matches.Update(parsedMatch).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Updated Match with ID ${matchInDb.Id}");
                return _mapper.Map<MatchDto>(matchInDb);
            }

            _logger.LogError($"Couldn't update Match with ID ${id}");
            return null;
        }

        public async Task<bool> MatchExistsInDb(int id) =>
            await _footballContext.Matches.AnyAsync(m => m.Id == id);

        private IQueryable<Match> GetMatchesWithAllData()
        {
            return _footballContext.Matches
                .Include(m => m.AwayPlayers)
                .ThenInclude(ap => ap.Player)
                .Include(m => m.HousePlayers)
                .ThenInclude(hp => hp.Player)
                .Include(m => m.Referee)
                .Include(m => m.HouseManager)
                .Include(m => m.AwayManager);
        }
    }
}
