using Football.API.Models;

namespace Football.Database.Models
{
    public class AwayPlayerDto
    {
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
