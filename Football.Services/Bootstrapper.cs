using Football.API.Services;
using Football.Services.Contracts;
using Football.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Football.Services
{
    public class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IRefereeService, RefereeService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
        }
    }
}
