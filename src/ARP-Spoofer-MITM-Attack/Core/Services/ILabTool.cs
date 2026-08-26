using ARPSpooferMITMAttack.Core.Models;

namespace ARPSpooferMITMAttack.Core.Services
{
    public interface ILabTool
    {
        Task<LabResult> RunAsync(string target, CancellationToken cancellationToken = default);
        Task<LabSnapshot> GetLatestSnapshotAsync(CancellationToken cancellationToken = default);
    }
}
