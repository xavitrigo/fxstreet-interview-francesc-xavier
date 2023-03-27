using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Models;
using Football.Services.Services;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly IRefereeService _refereeService;

        public RefereeController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
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
                this.NotFound();
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
                return this.NotFound();

            await _refereeService.UpdateReferee(id, referee);
            return this.Ok();
        }
    }
}
