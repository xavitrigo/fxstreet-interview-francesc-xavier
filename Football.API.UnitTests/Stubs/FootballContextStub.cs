using Football.Database;
using Microsoft.EntityFrameworkCore;

namespace Football.API.UnitTests.Stubs
{
    public class FootballContextStub : FootballContext
    {
        public FootballContextStub(string connectionString) : base(connectionString) { }

        public FootballContextStub(DbContextOptions<FootballContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
