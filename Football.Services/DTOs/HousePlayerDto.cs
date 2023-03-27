using Football.API.Models;

namespace Football.Database.Models
{
    public class HousePlayerDto
    {
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
