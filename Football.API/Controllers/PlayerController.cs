using Football.API.Models;
using Football.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
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
                this.NotFound();
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
                return this.NotFound();

            await _playerService.UpdatePlayer(id, player);
            return this.Ok();
        }
    }
}
