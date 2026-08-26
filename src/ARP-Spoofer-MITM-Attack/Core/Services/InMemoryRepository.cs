using ARPSpooferMITMAttack.Core.Models;

namespace ARPSpooferMITMAttack.Core.Services
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<LabResult> _results = new();
        private readonly SemaphoreSlim _lock = new(1, 1);

        public async Task SaveResultAsync(LabResult result, CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try { _results.Add(result); } finally { _lock.Release(); }
        }

        public async Task<List<LabResult>> GetResultsAsync(CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try { return _results.ToList(); } finally { _lock.Release(); }
        }
    }
}
