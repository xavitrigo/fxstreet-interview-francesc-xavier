using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Football.Database
{
    public class FootballContextFactory : IDesignTimeDbContextFactory<FootballContext>
    {
        public FootballContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FootballContext>();
            var config = new ConfigurationBuilder().AddJsonFile("Config/appsettings.json").Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new FootballContext(optionsBuilder.Options);
        }
    }
}
