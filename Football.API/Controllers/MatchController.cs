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
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly ILogger<MatchController> _logger;

        public MatchController(
            IMatchService matchService,
            ILogger<MatchController> logger
        ) {
            _matchService = matchService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Match>>> Get()
        {
            var matches = await _matchService.GetAllMatchs();
            return this.Ok(matches);
        }
        
        [HttpGet]
        [Route("{id}", Name = "GetMatchById")]
        public async Task<ActionResult> GetMatchById(int id)
        {
            var match = await _matchService.GetMatchById(id);
            if (match == default)
            {
                _logger.LogError($"Match to get with ID ${id} not found");
                this.NotFound();
            }
                
            return this.Ok(match);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MatchDto match)
        {
            var matchInDb = await _matchService.AddMatch(match);
            return this.CreatedAtAction(nameof(GetMatchById), new { matchInDb.Id }, matchInDb);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, MatchDto match)
        {
            var isMatchInDb = await _matchService.MatchExistsInDb(id);
            if (!isMatchInDb)
            {
                _logger.LogError($"Match to update with ID ${id} not found");
                return this.NotFound();
            }
            
            await _matchService.UpdateMatch(id, match);
            return this.Ok();
        }
    }
}
