using Microsoft.Extensions.Configuration;

namespace ARPSpooferMITMAttack.Infrastructure.Configuration
{
    public static class EnvironmentLoader
    {
        public static IConfigurationRoot Load(string[]? args = null)
        {
            return new ConfigurationBuilder()
                .AddEnvironmentVariables("ARPWATCHER_")
                .AddCommandLine(args ?? Array.Empty<string>())
                .Build();
        }
    }
}
