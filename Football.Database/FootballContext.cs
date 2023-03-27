using Football.API.Models;
using Football.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Football.Database
{
    public class FootballContext : DbContext
    {

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new RefereeConfiguration());
            modelBuilder.ApplyConfiguration(new AwayPlayerConfiguration());
            modelBuilder.ApplyConfiguration(new HousePlayerConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
        }

        #region DbSetup
        private readonly string _connectionString;
        public FootballContext(string connectionString) { _connectionString = connectionString; }
        public FootballContext(DbContextOptions<FootballContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
        #endregion
    }
}
