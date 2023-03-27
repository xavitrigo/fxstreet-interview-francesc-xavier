using Football.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Football.Database.Configuration
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        private readonly Manager[] _dataToSeed =
        {
            new Manager { Id = 1, Name = "Alex", RedCard = 1, YellowCard = 0 },
            new Manager { Id = 2, Name = "Zidane", RedCard = 0, YellowCard = 1 },
            new Manager { Id = 3, Name = "Guardiola", RedCard = 0, YellowCard = 1 },
            new Manager { Id = 4, Name = "Rafa", RedCard = 0, YellowCard = 2 },
            new Manager { Id = 5, Name = "Jose", RedCard = 2, YellowCard = 2 },
            new Manager { Id = 6, Name = "Ancelotti", RedCard = 1, YellowCard = 1 },
            new Manager { Id = 7, Name = "Diego", RedCard = 0, YellowCard = 0 }
        };

        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable(nameof(Manager), Schemas.Public);

            //When you seed data, Posgres keeps the start ID to 1 instead of 8.
            //So you have to specify manually the ID from where to start in order
            //to autoincrement the ID when you add a new entity
            builder.Property(r => r.Id)
                .HasIdentityOptions(startValue: LastIdOfDataToSeed())
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired(true);
            builder.Property(m => m.YellowCard).HasDefaultValue(0);
            builder.Property(m => m.RedCard).HasDefaultValue(0);

            foreach(var manager in _dataToSeed)
            {
                builder.HasData(manager);
            }
        }

        private int LastIdOfDataToSeed() => _dataToSeed.Max(m => m.Id) + 1;
    }
}
