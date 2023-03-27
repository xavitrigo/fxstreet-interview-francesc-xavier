using Football.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Football.Database.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        private readonly Player[] _dataToSeed = 
        {
            new Player { Id = 1, Name = "Lionel", MinutesPlayed = 78, RedCard = 1, YellowCard = 1 },
            new Player { Id = 2, Name = "Cristiano", MinutesPlayed = 52, RedCard = 1, YellowCard = 2 },
            new Player { Id = 3, Name = "Iker", MinutesPlayed = 23, RedCard = 2, YellowCard = 3 },
            new Player { Id = 4, Name = "Gerard", MinutesPlayed = 67, RedCard = 0, YellowCard = 4 },
            new Player { Id = 5, Name = "Philippe", MinutesPlayed = 80, RedCard = 0, YellowCard = 1 },
            new Player { Id = 6, Name = "Jordi", MinutesPlayed = 90, RedCard = 2, YellowCard = 0 },
            new Player { Id = 7, Name = "Kylian", MinutesPlayed = 65, RedCard = 3, YellowCard = 1 },
            new Player { Id = 8, Name = "Fran", MinutesPlayed = 35, RedCard = 1, YellowCard = 3 },
            new Player { Id = 9, Name = "Geronimo", MinutesPlayed = 48, RedCard = 0, YellowCard = 1 },
            new Player { Id = 10, Name = "Karim", MinutesPlayed = 23, RedCard = 1, YellowCard = 1 },
            new Player { Id = 11, Name = "Sadio", MinutesPlayed = 76, RedCard = 2, YellowCard = 1 },
            new Player { Id = 12, Name = "Fabinho", MinutesPlayed = 77, RedCard = 3, YellowCard = 3 },
            new Player { Id = 13, Name = "Luka", MinutesPlayed = 54, RedCard = 3, YellowCard = 1 },
            new Player { Id = 14, Name = "Rafael", MinutesPlayed = 68, RedCard = 1, YellowCard = 2 },
            new Player { Id = 15, Name = "Bernardo", MinutesPlayed = 89, RedCard = 1, YellowCard = 3 },
            new Player { Id = 16, Name = "Antonio", MinutesPlayed = 12, RedCard = 2, YellowCard = 4 },
            new Player { Id = 17, Name = "Pedri", MinutesPlayed = 68, RedCard = 0, YellowCard = 5 },
            new Player { Id = 18, Name = "Theo", MinutesPlayed = 58, RedCard = 0, YellowCard = 2 },
            new Player { Id = 19, Name = "Cristiano", MinutesPlayed = 36, RedCard = 1, YellowCard = 4 },
            new Player { Id = 20, Name = "Gavi", MinutesPlayed = 71, RedCard = 3, YellowCard = 1 },
            new Player { Id = 21, Name = "Lautaro", MinutesPlayed = 86, RedCard = 2, YellowCard = 0 },
            new Player { Id = 22, Name = "Joshua", MinutesPlayed = 82, RedCard = 2, YellowCard = 0 },
            new Player { Id = 23, Name = "Eder", MinutesPlayed = 90, RedCard = 1, YellowCard = 1 },
            new Player { Id = 24, Name = "Harry", MinutesPlayed = 39, RedCard = 1, YellowCard = 2 },
            new Player { Id = 25, Name = "Thomas", MinutesPlayed = 57, RedCard = 3, YellowCard = 3 },
            new Player { Id = 26, Name = "Rafael", MinutesPlayed = 51, RedCard = 4, YellowCard = 4 },
            new Player { Id = 27, Name = "Raul", MinutesPlayed = 12, RedCard = 0, YellowCard = 1 },
            new Player { Id = 28, Name = "Mason", MinutesPlayed = 87, RedCard = 1, YellowCard = 1 },
            new Player { Id = 29, Name = "Andrew", MinutesPlayed = 64, RedCard = 2, YellowCard = 3 },
            new Player { Id = 30, Name = "Recee", MinutesPlayed = 56, RedCard = 2, YellowCard = 2 },
        };

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(nameof(Player), Schemas.Public);

            builder.Property(r => r.Id)
                .HasIdentityOptions(startValue: LastIdOfDataToSeed())
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired(true);
            builder.Property(p => p.YellowCard).HasDefaultValue(0);
            builder.Property(p => p.RedCard).HasDefaultValue(0);
            builder.Property(p => p.MinutesPlayed).HasDefaultValue(0);

            foreach(var player in _dataToSeed)
            {
                builder.HasData(player);
            }
        }

        private int LastIdOfDataToSeed() => _dataToSeed.Max(m => m.Id) + 1;
    }
}
