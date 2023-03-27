using Football.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Database.Configuration
{
    public class HousePlayerConfiguration : IEntityTypeConfiguration<HousePlayer>
    {
        private readonly HousePlayer[] _dataToSeed =
        {
            new HousePlayer { MatchId = 1, PlayerId = 16 },
            new HousePlayer { MatchId = 1, PlayerId = 17 },
            new HousePlayer { MatchId = 1, PlayerId = 18 },
            new HousePlayer { MatchId = 1, PlayerId = 19 },
            new HousePlayer { MatchId = 1, PlayerId = 20 },
            new HousePlayer { MatchId = 2, PlayerId = 21 },
            new HousePlayer { MatchId = 2, PlayerId = 22 },
            new HousePlayer { MatchId = 2, PlayerId = 24 },
            new HousePlayer { MatchId = 2, PlayerId = 25 },
        };

        public void Configure(EntityTypeBuilder<HousePlayer> builder)
        {
            builder.ToTable(nameof(HousePlayer), Schemas.Public);

            builder.HasKey(ap => new { ap.PlayerId, ap.MatchId });
            builder.HasOne(ap => ap.Match).WithMany(p => p.HousePlayers);

            foreach(var housePlayer in _dataToSeed)
            {
                builder.HasData(housePlayer);
            }
        }
    }
}
