using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.API.Models;
using Football.Database;
using Football.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Football.Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayerService> _logger;

        public PlayerService(
            FootballContext footballContext,
            IMapper mapper,
            ILogger<PlayerService> logger
        ) {
            _footballContext = footballContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<PlayerDto>> GetAllPlayers()
        {
            var players = await _footballContext.Players
                .Select(p => _mapper.Map<PlayerDto>(p))
                .ToListAsync();
            return players;
        }

        public async Task<PlayerDto> GetPlayerById(int id)
        {
            var player = await _footballContext.Players
                .AsNoTracking() //Detatch the entity so when it's getted, you can updated it
                .FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> AddPlayer(PlayerDto newPlayer)
        {
            var parsedPlayer = _mapper.Map<Player>(newPlayer);
            parsedPlayer.Id = 0; //ID will be setted automatically 

            var playerInDb = await _footballContext.Players.AddAsync(parsedPlayer);
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Created Player with ID ${playerInDb.Entity.Id}");
                return _mapper.Map<PlayerDto>(playerInDb.Entity);
            }

            _logger.LogError($"Couldn't create Player with ID ${playerInDb.Entity.Id}");
            return null;
        }

        public async Task<PlayerDto> UpdatePlayer(int id, PlayerDto newPlayer)
        {
            var parsedPlayer = _mapper.Map<Player>(newPlayer);
            parsedPlayer.Id = id; //To make sure the right entity is updated

            var playerInDb = _footballContext.Players.Update(parsedPlayer).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Updated Player with ID ${playerInDb.Id}");
                return _mapper.Map<PlayerDto>(playerInDb);
            }

            _logger.LogError($"Couldn't update Player with ID ${id}");
            return null;
        }

        public async Task<bool> PlayerExistsInDb(int id) =>
            await _footballContext.Players.AnyAsync(p => p.Id == id);
    }
}
