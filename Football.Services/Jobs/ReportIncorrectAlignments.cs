using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using NCrontab;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Football.Services.Jobs
{
    public class ReportIncorrectAlignmentsJob : BackgroundService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _config;
        private readonly ILogger<ReportIncorrectAlignmentsJob> _logger;
        private readonly string _incorrectAlignmentsEndpoint;
        private readonly string ApplicationJson = "application/json";
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "* */5 * * * *"; //Runs every 5 min

        public ReportIncorrectAlignmentsJob(
            IConfiguration configuration,
            ILogger<ReportIncorrectAlignmentsJob> logger
        ) {
            _incorrectAlignmentsEndpoint = configuration.GetSection("EndPoints").GetValue<string>("IncorrectAlignment");
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            _config = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                if (now > _nextRun)
                {
                    Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private async Task Process()
        {
            //TODO: What IDs should I send? Missing documentation
            int[] incorrectIds = { };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_incorrectAlignmentsEndpoint),
                Content = new StringContent(JsonConvert.SerializeObject(incorrectIds), Encoding.UTF8, ApplicationJson),
            };

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                //TODO: How to handle the incorrect IDs
                _logger.LogInformation("Incorrect aligment reported successfully");
            } 
            else
            {
                _logger.LogInformation($"Incorrect aligment couldn't be reported. Error code: ${response.StatusCode}");
            }
        }
    }
}
