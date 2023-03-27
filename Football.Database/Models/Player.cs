using Football.Database.Models;

namespace Football.API.Models
{
    public class Player : FootballModel
    {
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
