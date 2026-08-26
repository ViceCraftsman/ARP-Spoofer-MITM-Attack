using ARPSpooferMITMAttack.Core.Models;

namespace ARPSpooferMITMAttack.Core.Services
{
    public interface IDataProvider
    {
        Task<LabResult> FetchAsync(string target, CancellationToken cancellationToken = default);
    }
}
