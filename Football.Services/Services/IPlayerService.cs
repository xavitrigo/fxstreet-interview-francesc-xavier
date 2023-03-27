using Football.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public interface IPlayerService
    {
        Task<ICollection<PlayerDto>> GetAllPlayers();
        Task<PlayerDto> GetPlayerById(int id);
        Task<PlayerDto> AddPlayer(PlayerDto newPlayer);
        Task<PlayerDto> UpdatePlayer(int id, PlayerDto newPlayer);
        Task<bool> PlayerExistsInDb(int id);
    }
}
