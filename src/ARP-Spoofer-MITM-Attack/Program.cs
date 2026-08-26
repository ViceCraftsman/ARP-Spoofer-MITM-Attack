using ARPSpooferMITMAttack.Core.Configuration;
using ARPSpooferMITMAttack.Core.Services;
using ARPSpooferMITMAttack.Core.Utils;
using ARPSpooferMITMAttack.Infrastructure.Configuration;
using ARPSpooferMITMAttack.Infrastructure.ConsoleUi;
using ARPSpooferMITMAttack.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ARPSpooferMITMAttack
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "ARPSpooferMITMAttack";
            var arguments = ArgumentParser.Parse(args);
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            var labTool = serviceProvider.GetRequiredService<ILabTool>();
            var healthChecker = serviceProvider.GetRequiredService<IHealthChecker>();
            var menuRenderer = serviceProvider.GetRequiredService<MenuRenderer>();
            logger.LogInformation("Lab tool module started");
            await healthChecker.CheckAsync(CancellationToken.None);
            PrintBanner();
            await RunInteractiveLoop(labTool, menuRenderer, logger, CancellationToken.None);
        }

        static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = ConfigurationLoader.Build(Array.Empty<string>());
            services.AddSingleton(configuration);
            services.AddSingleton(configuration.BindOptions());
            services.AddLogging(builder => builder.AddProvider(new ConsoleLoggerProvider()));
            services.AddSingleton<IDataProvider, SimulatedDataProvider>();
            services.AddSingleton<IRepository, InMemoryRepository>();
            services.AddSingleton<IHealthChecker, EndpointHealthChecker>();
            services.AddSingleton<MenuRenderer>();
            services.AddSingleton<ILabTool, LabTool>();
            return services;
        }

        static void PrintBanner() { System.Console.WriteLine("Lab tool module initialized."); }

        static async Task RunInteractiveLoop(ILabTool labTool, MenuRenderer menuRenderer, ILogger logger, CancellationToken cancellationToken)
        {
            var menuOptions = new[] { "Run simulation", "Show last snapshot", "Exit" };
            while (true)
            {
                menuRenderer.RenderHeader("ARPSpooferMITMAttack - Lab Tool Module");
                menuRenderer.RenderMenu(menuOptions);
                var choice = System.Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        System.Console.Write("Target: ");
                        var target = System.Console.ReadLine() ?? "localhost";
                        await labTool.RunAsync(target, cancellationToken);
                        break;
                    case "2":
                        var snapshot = await labTool.GetLatestSnapshotAsync(cancellationToken);
                        System.Console.WriteLine($"Snapshot contains {snapshot.Results.Count} results");
                        break;
                    case "3": return;
                    default: logger.LogWarning("Invalid choice"); break;
                }
            }
        }
    }
}
