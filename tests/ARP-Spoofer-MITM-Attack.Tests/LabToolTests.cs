using ARPSpooferMITMAttack.Core.Models;
using ARPSpooferMITMAttack.Core.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace ARPSpooferMITMAttack.Tests
{
    public class LabToolTests
    {
        private readonly LabTool _tool;
        public LabToolTests()
        {
            var provider = new SimulatedDataProvider(NullLogger<SimulatedDataProvider>.Instance);
            var repository = new InMemoryRepository();
            _tool = new LabTool(provider, repository, NullLogger<LabTool>.Instance);
        }

        [Fact]
        public async Task RunAsync_SavesResult()
        {
            var result = await _tool.RunAsync("localhost");
            Assert.NotNull(result);
            Assert.Equal("localhost", result.Target);
            var snapshot = await _tool.GetLatestSnapshotAsync();
            Assert.Single(snapshot.Results);
        }
    }
}
