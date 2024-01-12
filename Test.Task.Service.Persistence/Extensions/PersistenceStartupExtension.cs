using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Task.Service.Persistence.Extension;

public static class PersistenceStartupExtension
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(optionsAction: options =>
        {
            options.UseNpgsql(configuration["ConnectionStrings:PostgresConnection:connectionString"] +
                              $"Database={configuration["ConnectionStrings:PostgresConnection:Database"]};");
        }, ServiceLifetime.Transient);
        
        return services;
    }
}