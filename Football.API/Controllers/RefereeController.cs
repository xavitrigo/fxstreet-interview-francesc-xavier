using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Models;
using Football.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly IRefereeService _refereeService;
        private readonly ILogger<PlayerController> _logger;

        public RefereeController(
            IRefereeService refereeService,
            ILogger<PlayerController> logger
        ) {
            _refereeService = refereeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Referee>>> Get()
        {
            var referees = await _refereeService.GetAllReferees();
            return this.Ok(referees);
        }

        [HttpGet]
        [Route("{id}", Name = "GetRefereeById")]
        public async Task<ActionResult> GetRefereeById(int id)
        {
            var referee = await _refereeService.GetRefereeById(id);
            if (referee == default)
            {
                _logger.LogError($"Referee to get with ID ${id} not found");
                this.NotFound();
            }
                
            return this.Ok(referee);
        }

        [HttpPost]
        public async Task<ActionResult> Post(RefereeDto referee)
        {
            var refereeInDb = await _refereeService.AddReferee(referee);
            return this.CreatedAtAction(nameof(GetRefereeById), new { refereeInDb.Id }, refereeInDb);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, RefereeDto referee)
        {
            var isManagerInDb = await _refereeService.RefereeExistsInDb(id);
            if (!isManagerInDb)
            {
                _logger.LogError($"Referee to update with ID ${id} not found");
                return this.NotFound();
            }

            await _refereeService.UpdateReferee(id, referee);
            return this.Ok();
        }
    }
}
