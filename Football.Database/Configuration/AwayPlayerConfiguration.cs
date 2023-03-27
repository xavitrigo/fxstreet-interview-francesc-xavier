using Football.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Database.Configuration
{
    public class AwayPlayerConfiguration : IEntityTypeConfiguration<AwayPlayer>
    {
        private readonly AwayPlayer[] _dataToSeed = 
        { 
            new AwayPlayer { MatchId = 1, PlayerId = 7 },
            new AwayPlayer { MatchId = 1, PlayerId = 8 },
            new AwayPlayer { MatchId = 1, PlayerId = 9 },
            new AwayPlayer { MatchId = 1, PlayerId = 10 },
            new AwayPlayer { MatchId = 1, PlayerId = 11 },
            new AwayPlayer { MatchId = 2, PlayerId = 12 },
            new AwayPlayer { MatchId = 2, PlayerId = 13 },
            new AwayPlayer { MatchId = 2, PlayerId = 14 },
            new AwayPlayer { MatchId = 2, PlayerId = 15 },
        };

        public void Configure(EntityTypeBuilder<AwayPlayer> builder)
        {
            builder.ToTable(nameof(AwayPlayer), Schemas.Public);

            builder.HasKey(ap => new { ap.PlayerId, ap.MatchId });
            builder.HasOne(ap => ap.Match).WithMany(m => m.AwayPlayers);

            foreach(var awayPlayer in _dataToSeed)
            {
                builder.HasData(awayPlayer);
            }
        }
    }
}
