using Football.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Football.Database.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        private readonly Match[] _dataToSeed =
        {
            new Match {
                Id = 1,
                HouseManagerId = 3,
                AwayManagerId = 4,
                RefereeId = 3,
            },
            new Match {
                Id = 2,
                HouseManagerId = 5,
                AwayManagerId = 6,
                RefereeId = 4,
            }
        };

        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable(nameof(Match), Schemas.Public);

            builder.Property(r => r.Id)
                .HasIdentityOptions(startValue: LastIdOfDataToSeed())
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.HasOne(m => m.HouseManager);
            builder.HasOne(m => m.AwayManager);
            builder.HasOne(m => m.Referee);

            foreach(var match in _dataToSeed)
            {
                builder.HasData(match);
            }
        }

        private int LastIdOfDataToSeed() => _dataToSeed.Max(m => m.Id) + 1;
    }
}
