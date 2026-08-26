using ARPSpooferMITMAttack.Core.Models;

namespace ARPSpooferMITMAttack.Core.Services
{
    public interface IRepository
    {
        Task SaveResultAsync(LabResult result, CancellationToken cancellationToken = default);
        Task<List<LabResult>> GetResultsAsync(CancellationToken cancellationToken = default);
    }
}
