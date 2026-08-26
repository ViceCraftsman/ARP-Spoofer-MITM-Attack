using ARPSpooferMITMAttack.Core.Events;
using ARPSpooferMITMAttack.Core.Pipelines;
using ARPSpooferMITMAttack.Infrastructure.Events;
using ARPSpooferMITMAttack.Infrastructure.Metrics;
using ARPSpooferMITMAttack.Infrastructure.Persistence;
using ARPSpooferMITMAttack.Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace ARPSpooferMITMAttack.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IJsonRepository<>), typeof(JsonRepository<>));
            services.AddSingleton<IRequestValidator<object>, DefaultRequestValidator<object>>();
            services.AddSingleton<IMetricsPublisher, ConsoleMetricsPublisher>();
            services.AddSingleton<IDomainEventBus, InMemoryDomainEventBus>();
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            return services;
        }
    }
}
