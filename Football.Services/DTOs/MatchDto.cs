using Football.Database.Models;
using System.Collections.Generic;

namespace Football.API.Models
{
    public class MatchDto
    {
        public int? Id { get; set; }
        public int HouseManagerId { get; set; }
        public ManagerDto HouseManager { get; set; }
        public int AwayManagerId { get; set; }
        public ManagerDto AwayManager { get; set; }
        public virtual ICollection<HousePlayerDto> HousePlayers { get; set; }
        public virtual ICollection<AwayPlayerDto> AwayPlayers { get; set; }
        public int RefereeId { get; set; }
        public RefereeDto Referee { get; set; }
    }
}
