using ARPSpooferMITMAttack.Core.Models;
using Microsoft.Extensions.Logging;

namespace ARPSpooferMITMAttack.Core.Services
{
    public class SimulatedDataProvider : IDataProvider
    {
        private readonly ILogger<SimulatedDataProvider> _logger;
        private readonly Random _random = new();

        public SimulatedDataProvider(ILogger<SimulatedDataProvider> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<LabResult> FetchAsync(string target, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching simulated data for {Target}", target);
            return Task.FromResult(new LabResult
            {
                Target = target,
                Status = "simulated",
                Score = Math.Round(_random.NextDouble() * 100, 2)
            });
        }
    }
}
