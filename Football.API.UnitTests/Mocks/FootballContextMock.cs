using Football.Database;
using Microsoft.EntityFrameworkCore;

namespace Football.API.UnitTests.Mocks
{
    public class FootballContextMock : FootballContext
    {
        public FootballContextMock(string connectionString) : base(connectionString) { }

        public FootballContextMock(DbContextOptions<FootballContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
