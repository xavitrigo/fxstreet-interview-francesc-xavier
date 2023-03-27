using Football.API.Models;
using Football.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(
            IPlayerService playerService,
            ILogger<PlayerController> logger
        ) {
            _playerService = playerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var players = await _playerService.GetAllPlayers();
            return this.Ok(players);
        }

        [HttpGet]
        [Route("{id}", Name = "GetPlayerById")]
        public async Task<ActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayerById(id);
            if (player == default)
            {
                _logger.LogError($"Player to get with ID ${id} not found");
                this.NotFound();
            }
                
            return this.Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PlayerDto player)
        {
            var playerInDb = await _playerService.AddPlayer(player);
            return this.CreatedAtAction(nameof(GetPlayerById), new { playerInDb.Id }, playerInDb);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, PlayerDto player)
        {
            var isPlayerInDb = await _playerService.PlayerExistsInDb(id);
            if (!isPlayerInDb)
            {
                _logger.LogError($"Player to update with ID ${id} not found");
                return this.NotFound();
            }
                

            await _playerService.UpdatePlayer(id, player);
            return this.Ok();
        }
    }
}
