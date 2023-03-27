using AutoMapper;
using Football.API.Models;
using Football.Database.Models;

namespace Football.API
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Referee, RefereeDto>();
            CreateMap<RefereeDto, Referee>();

            CreateMap<Manager, ManagerDto>();
            CreateMap<ManagerDto, Manager>();

            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();

            CreateMap<Match, MatchDto>();
            CreateMap<MatchDto, Match>();

            CreateMap<AwayPlayer, AwayPlayerDto>();
            CreateMap<AwayPlayerDto, AwayPlayer>();

            CreateMap<HousePlayer, HousePlayerDto>();
            CreateMap<HousePlayerDto, HousePlayer>();
        }
    }
}
