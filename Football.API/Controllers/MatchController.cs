using Football.API.Models;
using Football.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            this._matchService = matchService;
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
                this.NotFound();
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
                return this.NotFound();

            await _matchService.UpdateMatch(id, match);
            return this.Ok();
        }
    }
}
