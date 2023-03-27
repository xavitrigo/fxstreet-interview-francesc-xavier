using Football.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Football.Database.Configuration
{
    public class RefereeConfiguration : IEntityTypeConfiguration<Referee>
    {
        private readonly Referee[] _dataToSeed =
        {
            new Referee { Id = 1, Name = "Pierluigi" },
            new Referee { Id = 2, Name = "Howard" },
            new Referee { Id = 3, Name = "Mateu" },
            new Referee { Id = 4, Name = "Luis" }
        };

        public void Configure(EntityTypeBuilder<Referee> builder)
        {
            builder.ToTable(nameof(Referee), Schemas.Public);

            builder.Property(r => r.Id)
                .HasIdentityOptions(startValue: LastIdOfDataToSeed())
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(r => r.Name).IsRequired(true);
            builder.Property(r => r.MinutesPlayed).HasDefaultValue(0);

            foreach(var referee in _dataToSeed)
            {
                builder.HasData(referee);
            }
        }

        private int LastIdOfDataToSeed() => _dataToSeed.Max(m => m.Id) + 1;
    }
}
