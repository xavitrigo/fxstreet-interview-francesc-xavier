using Football.Database.Models;

namespace Football.API.Models
{
    public class Referee : FootballModel
    {
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
