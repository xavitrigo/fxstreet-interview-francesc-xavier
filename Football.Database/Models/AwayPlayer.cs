using Football.API.Models;

namespace Football.Database.Models
{
    public class AwayPlayer
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
