using Microsoft.Extensions.Configuration;
using ARPSpooferMITMAttack.Core.Configuration;

namespace ARPSpooferMITMAttack.Infrastructure.Configuration
{
    public static class ConfigurationLoader
    {
        public static IConfiguration Build(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables("LAB_")
                .Build();
        }

        public static LabOptions BindOptions(this IConfiguration configuration)
        {
            var options = new LabOptions();
            configuration.GetSection("Lab").Bind(options);
            return options;
        }
    }
}
