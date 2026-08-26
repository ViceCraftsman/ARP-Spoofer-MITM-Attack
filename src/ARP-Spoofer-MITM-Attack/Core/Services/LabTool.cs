using ARPSpooferMITMAttack.Core.Models;
using Microsoft.Extensions.Logging;

namespace ARPSpooferMITMAttack.Core.Services
{
    public class LabTool : ILabTool
    {
        private readonly IDataProvider _dataProvider;
        private readonly IRepository _repository;
        private readonly ILogger<LabTool> _logger;

        public LabTool(IDataProvider dataProvider, IRepository repository, ILogger<LabTool> logger)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<LabResult> RunAsync(string target, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Running lab simulation for {Target}", target);
            var result = await _dataProvider.FetchAsync(target, cancellationToken);
            await _repository.SaveResultAsync(result, cancellationToken);
            return result;
        }

        public async Task<LabSnapshot> GetLatestSnapshotAsync(CancellationToken cancellationToken = default)
        {
            var results = await _repository.GetResultsAsync(cancellationToken);
            return new LabSnapshot { Results = results };
        }
    }
}
