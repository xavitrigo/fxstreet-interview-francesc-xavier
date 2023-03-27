using Football.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("yellowcards")]
        public async Task<ActionResult> GetYellowCards()
        {
            var yellowCardsPerMatch = await _statisticsService.GetYellowCards();
            return this.Ok(yellowCardsPerMatch);
        }

        [HttpGet]
        [Route("redcards")]
        public async Task<ActionResult> GetRedCards()
        {
            var redCardsPerMatch = await _statisticsService.GetRedCards();
            return this.Ok(redCardsPerMatch);
        }

        [HttpGet]
        [Route("minutesplayed")]
        public async Task<ActionResult> GetMinutesPlayed()
        {
            var minutesPlayedPerMatch = await _statisticsService.GetMinutesPlayed();
            return this.Ok(minutesPlayedPerMatch);
        }
    }
}
