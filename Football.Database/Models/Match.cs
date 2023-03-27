using Football.Database.Models;
using System.Collections.Generic;

namespace Football.API.Models
{
    public class Match : FootballModel
    {
        public int HouseManagerId { get; set; }
        public Manager HouseManager { get; set; }
        public int AwayManagerId { get; set; }
        public Manager AwayManager { get; set; }
        public virtual ICollection<HousePlayer> HousePlayers { get; set; }
        public virtual ICollection<AwayPlayer> AwayPlayers { get; set; }
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
    }
}
