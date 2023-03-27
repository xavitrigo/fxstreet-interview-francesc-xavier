using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.API.Models;
using Football.Database;

namespace Football.Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;

        public PlayerService(
            FootballContext footballContext,
            IMapper mapper
        ) {
            _footballContext = footballContext;
            _mapper = mapper;
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
            return entitiesSaved == 1 ? _mapper.Map<PlayerDto>(playerInDb.Entity) : null;
        }

        public async Task<PlayerDto> UpdatePlayer(int id, PlayerDto newPlayer)
        {
            var parsedPlayer = _mapper.Map<Player>(newPlayer);
            parsedPlayer.Id = id; //To make sure the right entity is updated

            var playerInDb = _footballContext.Players.Update(parsedPlayer).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();
            return entitiesSaved == 1 ? _mapper.Map<PlayerDto>(playerInDb) : null;
        }

        public async Task<bool> PlayerExistsInDb(int id) =>
            await _footballContext.Players.AnyAsync(p => p.Id == id);
    }
}
