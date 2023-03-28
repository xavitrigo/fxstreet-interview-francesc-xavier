using Football.API.Services;
using Football.Services.Services;
using Football.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Football.Services.Jobs;

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

            services.AddHostedService<ReportIncorrectAlignmentsJob>();
        }
    }
}
